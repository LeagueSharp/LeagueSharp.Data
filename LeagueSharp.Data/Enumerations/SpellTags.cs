namespace LeagueSharp.Data.Enumerations
{
    /// <summary>
    ///     Properties that a spell can have
    /// </summary>
    public enum SpellTags
    {
        /// <summary>
        ///     The spell deals damage
        /// </summary>
        Damage,

        /// <summary>
        ///     The spell's effects are AoE
        /// </summary>
        AoE,

        /// <summary>
        ///     The spell applies on-hit effects.
        /// </summary>
        AppliesOnHitEffects,

        /// <summary>
        ///     The spell applies CC
        /// </summary>
        CrowdControl,

        /// <summary>
        ///     The spell applies a shield on the target
        /// </summary>
        Shield,

        /// <summary>
        ///     The spell can heal
        /// </summary>
        Heal,

        /// <summary>
        ///     The spell makes the target enter a stasis state (invulnerable)
        /// </summary>
        Stasis,

        /// <summary>
        ///     The spell leaves a mark than can subsequently be proc'd to deal additional damage
        /// </summary>
        LeavesMark,

        /// <summary>
        ///     The spell can detonate a previously left mark.
        /// </summary>
        CanDetonateMark,

        /// <summary>
        ///     The spell modifies the champion's other spells (nida/jayce/elise ult)
        /// </summary>
        Transformation,

        /// <summary>
        ///     The spell is a dash
        /// </summary>
        Dash,

        /// <summary>
        ///     The spell is a blink
        /// </summary>
        Blink,

        /// <summary>
        ///     The spell teleports the champion
        /// </summary>
        Teleport,

        /// <summary>
        ///     The spell amplifies the damage dealt by attacks or spells
        /// </summary>
        DamageAmplifier,

        /// <summary>
        ///     The spell increases health/armor/mr
        /// </summary>
        DefensiveBuff,

        /// <summary>
        ///     The spell increases the target's movement speed
        /// </summary>
        MovementSpeedAmplifier,

        /// <summary>
        ///     The spell increases the target's Attack Speed
        /// </summary>
        AttackSpeedAmplifier,

        /// <summary>
        ///     The spell increases the target's Attack Range
        /// </summary>
        AttackRangeModifier,

        /// <summary>
        ///     The spell applies a spellshield
        /// </summary>
        SpellShield,

        /// <summary>
        ///     The spell removes all CC from target
        /// </summary>
        RemoveCrowdControl,

        /// <summary>
        ///     The spell grants vision of the target area.
        /// </summary>
        GrantsVision,

        /// <summary>
        ///     The spell can be interrupted
        /// </summary>
        Interruptable
    }
}