namespace LeagueSharp.Data.Enumerations
{
    /// <summary>
    ///     <c>SpellType</c> enumeration
    /// </summary>
    public enum SpellType
    {
        /// <summary>
        ///     The spell is a Circle Skillshot
        /// </summary>
        SkillshotCircle,

        /// <summary>
        ///     The spell is a Circle Skillshot that leaves a Missile
        /// </summary>
        SkillshotMissileCircle,

        /// <summary>
        ///     The spell is a Line Skillshot
        /// </summary>
        SkillshotLine,

        /// <summary>
        ///     The spell is a Line Skillshot that creates a Missile
        /// </summary>
        SkillshotMissileLine,

        /// <summary>
        ///     The spell is a Cone Skillshot
        /// </summary>
        SkillshotCone,

        /// <summary>
        ///     The spell is a Cone Skillshot that leaves a Missile
        /// </summary>
        SkillshotMissileCone,

        /// <summary>
        ///     The spell is an Arc Skillshot (Diana Q)
        /// </summary>
        SkillshotMissileArc,

        /// <summary>
        ///     The spell is a Ring Skillshot (Veigar E)
        /// </summary>
        SkillshotRing,

        /// <summary>
        ///     The spell is an Arc Skillshot
        /// </summary>
        SkillshotArc,

        /// <summary>
        ///     The spell is Targeted
        /// </summary>
        Targeted,

        /// <summary>
        ///     The spell is Targeted and has a missile.
        /// </summary>
        TargetedMissile,

        /// <summary>
        ///     The spell can be toggled on/off
        /// </summary>
        Toggled,

        /// <summary>
        ///     The spell can be activated, after which it lasts for a while (Vayne R, Olaf R)
        /// </summary>
        Activated,

        /// <summary>
        ///     The spell does nothing else but contain a passive (Vayne W, Mini Gnar W)
        /// </summary>
        Passive,

        /// <summary>
        ///     The spell is casted to a position like a skillshot but does undodgeable / random damage. Ezreal E, Ahri R...
        /// </summary>
        Position,

        /// <summary>
        ///     The spell must specify a start point and an end point (Viktor E, Rumble R)
        /// </summary>
        Vector
    }
}