namespace LeagueSharp.Data.DataTypes
{
    using System.Collections.Generic;

    using LeagueSharp.Data.Utility.Resources;

    /// <summary>
    ///     Gets champion priorities.
    /// </summary>
    /// <seealso cref="LeagueSharp.Data.IDataType" />
    [ResourceImport]
    public class ChampionPriorityData : IDataType
    {
        #region Static Fields

        [ResourceImport("Priority.json")]
        private static List<PriorityCategory> PriorityCategoriesList = new List<PriorityCategory>();

        #endregion

        #region Constructors and Destructors

        private ChampionPriorityData()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     The priority categories
        /// </summary>
        public IReadOnlyList<PriorityCategory> PriorityCategories => PriorityCategoriesList;

        #endregion
    }

    /// <summary>
    ///     Category class for Priorities
    /// </summary>
    public class PriorityCategory
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the champions.
        /// </summary>
        /// <value>
        ///     The champions.
        /// </value>
        public HashSet<string> Champions { get; set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public int Value { get; set; }

        #endregion
    }
}