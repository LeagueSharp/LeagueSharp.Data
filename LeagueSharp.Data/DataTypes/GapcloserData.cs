namespace LeagueSharp.Data.DataTypes
{
    using System.Collections.Generic;

    using LeagueSharp.Data.Enumerations;
    using LeagueSharp.Data.Utility.Resources;

    /// <summary>
    ///     Gets data on gapclosers.
    /// </summary>
    /// <seealso cref="IDataType" />
    [ResourceImport]
    public class GapcloserData : DataType<GapcloserData>
    {
        #region Static Fields

        /// <summary>
        ///     The spells
        /// </summary>
        [ResourceImport("GapcloserData.json")]
        private static Dictionary<string, GapcloserDataEntry> Spells = new Dictionary<string, GapcloserDataEntry>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Prevents a default instance of the <see cref="GapcloserData" /> class from being created.
        /// </summary>
        private GapcloserData()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the spells list.
        /// </summary>
        /// <value>
        ///     The spells list.
        /// </value>
        public IReadOnlyDictionary<string, GapcloserDataEntry> SpellsList => Spells;

        #endregion

        #region Public Indexers

        /// <summary>
        ///     Gets the <see cref="GapcloserDataEntry" /> with the specified champion name.
        /// </summary>
        /// <value>
        ///     The <see cref="GapcloserDataEntry" />.
        /// </value>
        /// <param name="name">The champion name.</param>
        /// <returns></returns>
        public GapcloserDataEntry this[string name] => this.SpellsList[name];

        #endregion
    }

    /// <summary>
    ///     GapCloser Data Container
    /// </summary>
    public struct GapcloserDataEntry
    {
        #region Public Properties

        /// <summary>
        ///     Spell Type
        /// </summary>
        public GapcloserType SkillType { get; set; }

        /// <summary>
        ///     Spell Slot
        /// </summary>
        public SpellSlot Slot { get; set; }

        /// <summary>
        ///     Spell Name
        /// </summary>
        public string SpellName { get; set; }

        #endregion
    }
}