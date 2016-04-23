namespace LeagueSharp.Data
{
    using System;
    using System.Collections.Generic;
    using System.Security.Permissions;

    using LeagueSharp.Data.Utility.Resources;

    public class Data
    {
        #region Static Fields

        /// <summary>
        ///     The cache
        /// </summary>
        internal static readonly Dictionary<Type, IDataType> Cache = new Dictionary<Type, IDataType>();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Gets the data of type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        public static T Get<T>() where T : IDataType
        {
            try
            {
                IDataType dataImpl;
                if (Cache.TryGetValue(typeof(T), out dataImpl))
                {
                    return (T)dataImpl;
                }

                dataImpl = (IDataType)Activator.CreateInstance(typeof(T), true);
                dataImpl.Initialize();

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
    public interface IDataType
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        void Initialize();

        #endregion
    }

    /// <summary>
    ///     Represents that a class has data that can be obtained from LeagueSharp.Data. Provides an implemenation to
    ///     automaticaly load JSON resources.
    /// </summary>
    public abstract class DataType<T> : IDataType
        where T : class
    {
        #region Explicit Interface Methods

        /// <summary>
        ///     Initializes the instance of the type.
        /// </summary>
        void IDataType.Initialize()
        {
            ResourceLoader.InitializeClass(typeof(T));
        }

        #endregion
    }
}