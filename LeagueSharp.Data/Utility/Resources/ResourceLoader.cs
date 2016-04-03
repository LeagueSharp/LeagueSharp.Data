namespace LeagueSharp.Data.Utility.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal static class ResourceLoader
    {
        #region Public Methods and Operators

        public static void Initialize()
        {
            var importClasses =
                typeof(ResourceLoader).Assembly.DefinedTypes.Where(
                    t => t.IsClass && t.IsDefined(typeof(ResourceImportAttribute), false));

            foreach (var c in importClasses)
            {
                foreach (var member in GetFieldsAndProperties(c))
                {
                    try
                    {
                        var valueType = member.GetMemberType();
                        var import = member.GetCustomAttribute<ResourceImportAttribute>();
                        var value = JsonFactory.JsonResource(import.File, valueType);

                        if (import.Filter != null)
                        {
                            if (
                                !import.Filter.GetInterfaces()
                                     .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IFilter<>)))
                            {
                                throw new Exception($"{nameof(import.Filter)} does not implement {nameof(IFilter)}");
                            }

                            var filterInstance = Activator.CreateInstance(import.Filter);
                            var apply = import.Filter.GetMethod("Apply", BindingFlags.Public | BindingFlags.Instance);

                            value = apply.Invoke(filterInstance, new[] { value });
                        }

                        member.SetValue(null, value);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(@"LeagueSharp.Data encountered an error trying to load the resources.
{0}", e);
                    }
                }
            }
        }

        #endregion

        #region Methods

        private static IEnumerable<MemberInfo> GetFieldsAndProperties(
            Type type,
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
        {
            return type.GetMembers(flags).Where(m => m.IsDefined(typeof(ResourceImportAttribute), false));
        }

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