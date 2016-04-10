namespace LeagueSharp.Data.Utility.Resources
{
    using System;

    /// <summary>
    ///     Marks a field/class that needs it's data from a JSON resource. Populated at runtime.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property)]
    internal class ResourceImportAttribute : Attribute
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ResourceImportAttribute" /> class.
        /// </summary>
        public ResourceImportAttribute()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ResourceImportAttribute" /> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ResourceImportAttribute(string file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            this.File = file;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the file.
        /// </summary>
        /// <value>
        ///     The file.
        /// </value>
        public string File { get; set; }

        /// <summary>
        ///     Gets or sets the filter.
        /// </summary>
        /// <value>
        ///     The filter.
        /// </value>
        public Type Filter { get; set; }

        #endregion
    }
}