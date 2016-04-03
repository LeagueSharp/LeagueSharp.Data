namespace LeagueSharp.Data.DataTypes
{
    using System.Collections.Generic;

    using LeagueSharp.Data.Enumerations;
    using LeagueSharp.Data.Utility.Resources;

    /// <summary>
    ///     Gets a list of gapclosers.
    /// </summary>
    [ResourceImport]
    public class GapcloserData : IDataType
    {
        #region Fields

        /// <summary>
        ///     The spells list
        /// </summary>
        [ResourceImport("Gapclosers.json")]
        public readonly Dictionary<string, GapCloserEntry> SpellsList = new Dictionary<string, GapCloserEntry>();

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
        public GapCloserEntry this[string name] => this.SpellsList[name];

        #endregion

        /// <summary>
        ///     GapCloser Data Container
        /// </summary>
        public struct GapCloserEntry
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