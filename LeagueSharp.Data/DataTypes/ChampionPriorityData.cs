namespace LeagueSharp.Data.DataTypes
{
    using System.Collections.Generic;

    using LeagueSharp.Data.Utility.Resources;

    /// <summary>
    ///     Gets champion priorities.
    /// </summary>
    /// <seealso cref="LeagueSharp.Data.DataType" />
    [ResourceImport]
    public class ChampionPriorityData : DataType
    {
        #region Static Fields

        [ResourceImport("PriorityData.json")]
        private static List<ChampionPriorityDataEntry> PriorityCategoriesList = new List<ChampionPriorityDataEntry>();

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
        public IReadOnlyList<ChampionPriorityDataEntry> PriorityCategories => PriorityCategoriesList;

        #endregion
    }

    /// <summary>
    ///     Category class for Priorities
    /// </summary>
    public class ChampionPriorityDataEntry
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