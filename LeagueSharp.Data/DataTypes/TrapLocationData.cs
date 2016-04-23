namespace LeagueSharp.Data.DataTypes
{
    using System.Collections.Generic;
    using System.Linq;

    using LeagueSharp.Data.Utility.Resources;

    using SharpDX;

    /// <summary>
    ///     Gets locations to place traps.
    /// </summary>
    /// <seealso cref="IDataType" />
    [ResourceImport]
    public class TrapLocationData : DataType<TrapLocationData>
    {
        #region Static Fields

        /// <summary>
        ///     The trap locations data
        /// </summary>
        [ResourceImport("TrapLocationsData.json")]
        private static List<TrapLocationDataEntry> TrapLocationsData = new List<TrapLocationDataEntry>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Prevents a default instance of the <see cref="TrapLocationData" /> class from being created.
        /// </summary>
        private TrapLocationData()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the trap locations.
        /// </summary>
        /// <value>
        ///     The trap locations.
        /// </value>
        public IReadOnlyList<TrapLocationDataEntry> TrapLocations => TrapLocationsData;

        #endregion

        #region Public Indexers

        /// <summary>
        ///     Gets the <see cref="List{Vector3}" /> with the specified map identifier.
        /// </summary>
        /// <value>
        ///     The <see cref="List{Vector3}" />.
        /// </value>
        /// <param name="mapId">The map identifier.</param>
        /// <returns></returns>
        public List<Vector3> this[int mapId]
        {
            get
            {
                return this.TrapLocations.FirstOrDefault(x => x.MapId == (int)Game.MapId)?.Locations;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Gets the locations of traps for the current map.
        /// </summary>
        /// <returns></returns>
        public List<Vector3> GetLocations()
        {
            return this.TrapLocations.FirstOrDefault(x => x.MapId == (int)Game.MapId)?.Locations;
        }

        #endregion
    }

    /// <summary>
    ///     JSON Wrapper for trap locations.
    /// </summary>
    public class TrapLocationDataEntry
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the locations to put traps.
        /// </summary>
        /// <value>
        ///     The locations to put traps.
        /// </value>
        public List<Vector3> Locations { get; set; } = new List<Vector3>();

        /// <summary>
        ///     Gets or sets the map identifier.
        /// </summary>
        /// <value>
        ///     The map identifier.
        /// </value>
        public int MapId { get; set; }

        #endregion
    }
}