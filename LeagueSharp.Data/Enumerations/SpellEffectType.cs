namespace LeagueSharp.Data.Enumerations
{
    /// <summary>
    ///     The type of effect a spell does.
    /// </summary>
    public enum SpellEffectType
    {
        /// <summary>
        ///     The spell has no effect.
        /// </summary>
        None,

        /// <summary>
        ///     Gets the AoE damage.
        /// </summary>
        AoE,

        /// <summary>
        ///     Gets the damage for a single attack if there is more than one attacks.
        /// </summary>
        Single,

        /// <summary>
        ///     Gets the damage overtime.
        /// </summary>
        OverTime,

        /// <summary>
        ///     Gets the damage when the target is attacked.
        /// </summary>
        Attack
    }
}