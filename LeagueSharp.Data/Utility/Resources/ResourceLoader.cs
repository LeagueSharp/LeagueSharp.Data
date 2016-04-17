namespace LeagueSharp.Data.Utility.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    /// <summary>
    ///     Loads JSON resources marked with the <see cref="ResourceImportAttribute" /> attribute.
    /// </summary>
    internal static class ResourceLoader
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void Initialize()
        {
            var importClasses =
                typeof(ResourceLoader).Assembly.DefinedTypes.Where(
                    t => t.IsClass && t.IsDefined(typeof(ResourceImportAttribute), false));

            var tasks = new List<Task>();

            foreach (var c in importClasses)
            {
                Parallel.ForEach(
                    GetFieldsAndProperties(c),
                    member =>
                        {
                            tasks.Add(
                                Task.Factory.StartNew(
                                    () =>
                                        {
                                            var valueType = member.GetMemberType();
                                            var import = member.GetCustomAttribute<ResourceImportAttribute>();
                                            var value = JsonFactory.JsonResource(import.File, valueType);

                                            if (import.Filter != null)
                                            {
                                                if (
                                                    !import.Filter.GetInterfaces()
                                                         .Any(
                                                             x =>
                                                             x.IsGenericType
                                                             && x.GetGenericTypeDefinition() == typeof(IFilter<>)))
                                                {
                                                    throw new Exception(
                                                        $"{nameof(import.Filter)} does not implement {nameof(IFilter)}");
                                                }

                                                var filterInstance = Activator.CreateInstance(import.Filter);
                                                var apply = import.Filter.GetMethod(
                                                    "Apply",
                                                    BindingFlags.Public | BindingFlags.Instance);

                                                value = apply.Invoke(filterInstance, new[] { value });
                                            }

                                            member.SetValue(null, value);
                                        }));
                        });

                Data.Cache[c] = (DataType)Activator.CreateInstance(c, true);
            }

            Task.WaitAll(tasks.ToArray());
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the fields and properties.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="flags">The flags.</param>
        /// <returns></returns>
        private static IEnumerable<MemberInfo> GetFieldsAndProperties(
            Type type,
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
        {
            return type.GetMembers(flags).Where(m => m.IsDefined(typeof(ResourceImportAttribute), false));
        }

        /// <summary>
        ///     Gets the type of the member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static Type GetMemberType(this MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)member).FieldType;

                case MemberTypes.Property:
                    return ((PropertyInfo)member).PropertyType;

                default:
                    throw new ArgumentException(
                        $"{nameof(MemberInfo)} must be if type {nameof(FieldInfo)} or {nameof(PropertyInfo)}",
                        nameof(member));
            }
        }

        /// <summary>
        ///     Sets the value of a member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <param name="target">The target.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException"></exception>
        private static void SetValue(this MemberInfo member, object target, object value)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    ((FieldInfo)member).SetValue(target, value);
                    break;

                case MemberTypes.Property:
                    ((PropertyInfo)member).SetValue(target, value, null);
                    break;

                default:
                    throw new ArgumentException(
                        $"{nameof(MemberInfo)} must be if type {nameof(FieldInfo)} or {nameof(PropertyInfo)}",
                        nameof(member));
            }
        }

        #endregion
    }
}