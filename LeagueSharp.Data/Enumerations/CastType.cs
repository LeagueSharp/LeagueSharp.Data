namespace LeagueSharp.Data.Enumerations
{
    /// <summary>
    ///     Indicates how a spell can be casted
    /// </summary>
    public enum CastType
    {
        /// <summary>
        ///     The spell can be casted on an enemy champion
        /// </summary>
        EnemyChampions,

        /// <summary>
        ///     The spell can be casted on an enemy minion
        /// </summary>
        EnemyMinions,

        /// <summary>
        ///     The spell can be casted on an enemy tower
        /// </summary>
        EnemyTurrets,

        /// <summary>
        ///     The spell can be casted on an ally champion
        /// </summary>
        AllyChampions,

        /// <summary>
        ///     The spell can be casted on an ally minion
        /// </summary>
        AllyMinions,

        /// <summary>
        ///     The spell can be casted on an ally turret
        /// </summary>
        AllyTurrets,

        /// <summary>
        ///     The spell can be casted only on pets.
        /// </summary>
        HeroPets,

        /// <summary>
        ///     The spell can be casted on a position
        /// </summary>
        Position,

        /// <summary>
        ///     The spell can be casted in a direction
        /// </summary>
        Direction,

        /// <summary>
        ///     The spell can be casted on self
        /// </summary>
        Self,

        /// <summary>
        ///     The spell is a charging spell
        /// </summary>
        Charging,

        /// <summary>
        ///     The spell is a toggleable spell
        /// </summary>
        Toggle,

        /// <summary>
        ///     The spell is a channel
        /// </summary>
        Channel,

        /// <summary>
        ///     The spell is activable
        /// </summary>
        Activate,

        /// <summary>
        ///     The spell can't be casted
        /// </summary>
        ImpossibleToCast
    }
}