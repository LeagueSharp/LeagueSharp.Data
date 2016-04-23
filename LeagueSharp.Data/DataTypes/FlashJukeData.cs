namespace LeagueSharp.Data.DataTypes
{
    using System.Collections.Generic;
    using System.Linq;

    using LeagueSharp.Data.Utility.Resources;

    using SharpDX;

    /// <summary>
    ///     Gets data for flash juke locations.
    /// </summary>
    /// <seealso cref="IDataType" />
    [ResourceImport]
    public class FlashJukeData : DataType<FlashJukeData>
    {
        #region Static Fields

        [ResourceImport("FlashJukeData.json")]
        private static List<FlashJukeDataEntry> FlashJukeEntries = new List<FlashJukeDataEntry>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Prevents a default instance of the <see cref="FlashJukeData" /> class from being created.
        /// </summary>
        private FlashJukeData()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the flash juke locations.
        /// </summary>
        /// <value>
        ///     The flash juke locations.
        /// </value>
        public IReadOnlyList<FlashJukeDataEntry> FlashJukeLocations => FlashJukeEntries;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Gets the closest flash juke spot.
        /// </summary>
        /// <returns></returns>
        public FlashJukeDataEntry GetClosestSpot()
        {
            return
                this.FlashJukeLocations.OrderBy(x => Vector3.Distance(ObjectManager.Player.ServerPosition, x.Start))
                    .FirstOrDefault();
        }

        #endregion
    }

    /// <summary>
    ///     A JSON wrapper for flash juke data.
    /// </summary>
    public class FlashJukeDataEntry
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the ending position for the flash juke. The player should walk here if not here already.
        /// </summary>
        /// <value>
        ///     The ending position for the flash juke.
        /// </value>
        public Vector3 End { get; set; }

        /// <summary>
        ///     Gets or sets the starting location for the flash juke.
        /// </summary>
        /// <value>
        ///     The starting location for the flash juke.
        /// </value>
        public Vector3 Start { get; set; }

        /// <summary>
        ///     Gets or sets the position to flash to.
        /// </summary>
        /// <value>
        ///     The position to flash to.
        /// </value>
        public Vector3 Target { get; set; }

        #endregion
    }
}