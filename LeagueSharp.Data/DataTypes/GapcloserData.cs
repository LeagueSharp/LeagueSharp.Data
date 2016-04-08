namespace LeagueSharp.Data.DataTypes
{
    using System.Collections.Generic;

    using LeagueSharp.Data.Enumerations;
    using LeagueSharp.Data.Utility.Resources;

    /// <summary>
    ///     Gets a list of gapclosers.
    /// </summary>
    [ResourceImport]
    public class GapcloserData : DataType<GapcloserData>
    {
        #region Fields

        /// <summary>
        ///     The spells list
        /// </summary>
        [ResourceImport("GapcloserData.json")]
        public readonly Dictionary<string, GapcloserDataEntry> SpellsList = new Dictionary<string, GapcloserDataEntry>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Prevents a default instance of the <see cref="GapcloserData" /> class from being created.
        /// </summary>
        private GapcloserData()
        {
        }

        #endregion

        #region Public Indexers

        /// <summary>
        ///     Gets the <see cref="GapCloserEntry" /> with the specified champion name.
        /// </summary>
        /// <value>
        ///     The <see cref="GapCloserEntry" />.
        /// </value>
        /// <param name="name">The champion name.</param>
        /// <returns></returns>
        public GapcloserDataEntry this[string name] => this.SpellsList[name];

        #endregion

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
}