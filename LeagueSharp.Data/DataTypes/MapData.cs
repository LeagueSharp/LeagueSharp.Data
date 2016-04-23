namespace LeagueSharp.Data.DataTypes
{
    using System.Collections.Generic;

    using LeagueSharp.Data.Utility.Resources;

    using SharpDX;

    /// <summary>
    ///     Gets data on maps.
    /// </summary>
    /// <seealso cref="IDataType" />
    [ResourceImport]
    public class MapData : DataType<MapData>
    {
        #region Static Fields

        [ResourceImport("MapData.json")]
        private static Dictionary<int, MapDataEntry> MapById = new Dictionary<int, MapDataEntry>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Prevents a default instance of the <see cref="MapData" /> class from being created.
        /// </summary>
        private MapData()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Map by ID list.
        /// </summary>
        public IReadOnlyDictionary<int, MapDataEntry> Maps => MapById;

        #endregion

        #region Public Indexers

        /// <summary>
        ///     Gets the <see cref="MapDataEntry" /> with the specified map identifier.
        /// </summary>
        /// <value>
        ///     The <see cref="MapDataEntry" />.
        /// </value>
        /// <param name="mapId">The map identifier.</param>
        /// <returns></returns>
        public MapDataEntry this[int mapId] => this.Maps[mapId];

        #endregion
    }

    public class MapDataEntry
    {
        #region Public Properties

        /// <summary>
        ///     Gets the Grid of the Map
        /// </summary>
        public Vector2 Grid { get; set; }

        /// <summary>
        ///     Gets the MapType
        /// </summary>
        public GameMapId MapId { get; set; }

        /// <summary>
        ///     Gets the name of the map
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets the short name of the map.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        ///     Gets the level the players start at
        /// </summary>
        public int StartingLevel { get; set; }

        #endregion
    }
}