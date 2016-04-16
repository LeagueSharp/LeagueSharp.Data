namespace LeagueSharp.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Security.Permissions;
    using System.Text;

    using LeagueSharp.Data.Utility.Resources;

    public class Data
    {
        #region Static Fields

        /// <summary>
        ///     The cache
        /// </summary>
        internal static readonly Dictionary<Type, DataType> Cache = new Dictionary<Type, DataType>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes the <see cref="Data" /> class.
        /// </summary>
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        static Data()
        {
            try
            {
                ResourceLoader.Initialize();
            }
            catch (ReflectionTypeLoadException ex)
            {
                var sb = new StringBuilder();
                foreach (var exSub in ex.LoaderExceptions)
                {
                    sb.AppendLine(exSub.Message);
                    var exFileNotFound = exSub as FileNotFoundException;
                    if (!string.IsNullOrEmpty(exFileNotFound?.FusionLog))
                    {
                        sb.AppendLine("Fusion Log:");
                        sb.AppendLine(exFileNotFound.FusionLog);
                    }
                    sb.AppendLine();
                }

                Console.WriteLine(sb.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Gets the data of type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        public static T Get<T>() where T : DataType
        {
            try
            {
                DataType dataImpl;
                if (Cache.TryGetValue(typeof(T), out dataImpl))
                {
                    return (T)dataImpl;
                }

                dataImpl = (DataType)Activator.CreateInstance(typeof(T), true);
                Cache[typeof(T)] = dataImpl;

                return (T)dataImpl;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default(T);
            }
        }

        #endregion
    }

    /// <summary>
    ///     Represents that a class has data that can be obtained from LeagueSharp.Data
    /// </summary>
    public abstract class DataType
    {
    }
}