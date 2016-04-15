namespace LeagueSharp.Data.DataTypes
{
    using System.Collections.Generic;
    using System.Linq;

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

        /// <summary>
        ///     Prevents a default instance of the <see cref="ChampionPriorityData" /> class from being created.
        /// </summary>
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

        #region Public Methods and Operators

        /// <summary>
        ///     Gets the champions.
        /// </summary>
        /// <param name="priorityLevel">The priority level.</param>
        /// <returns></returns>
        public string[] GetChampions(int priorityLevel)
        {
            return this.PriorityCategories.FirstOrDefault(x => x.Value == priorityLevel)?.Champions.ToArray()
                   ?? new string[0];
        }

        /// <summary>
        ///     Gets the priority.
        /// </summary>
        /// <param name="champion">The champion.</param>
        /// <returns></returns>
        public int GetPriority(string champion)
        {
            return this.PriorityCategories.FirstOrDefault(x => x.Champions.Contains(champion))?.Value ?? 2;
        }

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