namespace LeagueSharp.Data.DataTypes
{
    using System.Collections.Generic;

    using LeagueSharp.Data.Enumerations;
    using LeagueSharp.Data.Utility.Resources;

    /// <summary>
    ///     Gets data on interruptable spells.
    /// </summary>
    /// <seealso cref="IDataType" />
    /// <seealso cref="IDataType" />
    [ResourceImport]
    public class InterruptableSpellData : DataType<InterruptableSpellData>
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Prevents a default instance of the <see cref="InterruptableSpellData" /> class from being created.
        /// </summary>
        private InterruptableSpellData()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the interruptible spells dictionary.
        /// </summary>
        public IReadOnlyList<InterruptableSpellDataEntry> GlobalInterruptableSpells => GlobalInterruptableSpellsList;

        /// <summary>
        ///     Gets the interruptible spells dictionary.
        /// </summary>
        public IReadOnlyDictionary<string, List<InterruptableSpellDataEntry>> InterruptableSpells
            => InterruptableSpellsDictionary;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the global interruptable spells list.
        /// </summary>
        [ResourceImport("GlobalInterruptableSpellData.json")]
        private static List<InterruptableSpellDataEntry> GlobalInterruptableSpellsList { get; set; } =
            new List<InterruptableSpellDataEntry>();

        [ResourceImport("InterruptableSpellsData.json")]
        private static Dictionary<string, List<InterruptableSpellDataEntry>> InterruptableSpellsDictionary { get; set; }
            = new Dictionary<string, List<InterruptableSpellDataEntry>>();

        #endregion

        #region Public Indexers

        /// <summary>
        ///     Gets the <see cref="List{InterruptableSpellDataEntry}" /> with the specified champion name.
        /// </summary>
        /// <value>
        ///     The <see cref="List{InterruptableSpellDataEntry}" />.
        /// </value>
        /// <param name="championName">Name of the champion.</param>
        /// <returns></returns>
        public List<InterruptableSpellDataEntry> this[string championName] => this.InterruptableSpells[championName];

        #endregion
    }

    /// <summary>
    ///     Interrupt-able Spell Data
    /// </summary>
    public class InterruptableSpellDataEntry
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="InterruptableSpellData" /> class.
        /// </summary>
        public InterruptableSpellDataEntry()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InterruptableSpellData" /> class.
        /// </summary>
        /// <param name="slot">
        ///     Spell Slot
        /// </param>
        /// <param name="dangerLevel">
        ///     Danger Level
        /// </param>
        /// <param name="movementInterrupts">
        ///     Does movement interrupt the spell
        /// </param>
        public InterruptableSpellDataEntry(SpellSlot slot, DangerLevel dangerLevel, bool movementInterrupts = true)
        {
            this.Slot = slot;
            this.DangerLevel = dangerLevel;
            this.MovementInterrupts = movementInterrupts;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InterruptableSpellData" /> class.
        /// </summary>
        /// <param name="name">
        ///     Spell Name
        /// </param>
        /// <param name="dangerLevel">
        ///     Danger Level
        /// </param>
        /// <param name="slot">
        ///     The slot.
        /// </param>
        /// <param name="movementInterrupts">
        ///     Does movement interrupt the spell
        /// </param>
        public InterruptableSpellDataEntry(
            string name,
            DangerLevel dangerLevel,
            SpellSlot slot = SpellSlot.Unknown,
            bool movementInterrupts = true)
        {
            this.Name = name;
            this.DangerLevel = dangerLevel;
            this.Slot = slot;
            this.MovementInterrupts = movementInterrupts;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the danger level.
        /// </summary>
        public DangerLevel DangerLevel { get; set; }

        /// <summary>
        ///     Gets a value indicating whether movement interrupts.
        /// </summary>
        public bool MovementInterrupts { get; set; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets the slot.
        /// </summary>
        public SpellSlot Slot { get; set; }

        #endregion
    }
}