namespace LeagueSharp.Data.DataTypes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using LeagueSharp.Data.Enumerations;
    using LeagueSharp.Data.Properties;
    using LeagueSharp.Data.Utility.Resources;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    ///     Gets damages. Only loads damages for champions in the game.
    /// </summary>
    /// <seealso cref="DataType{T}" />
    [ResourceImport]
    public class DamageDatabase : DataType<DamageDatabase>
    {
        #region Static Fields

        /// <summary>
        ///     The damage version files.
        /// </summary>
        private static readonly IDictionary<string, byte[]> DamageFiles = new Dictionary<string, byte[]>
                                                                              { { "6.6", Resources._6_6 } };

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Prevents a default instance of the <see cref="DamageDatabase" /> class from being created.
        /// </summary>
        private DamageDatabase()
        {
            var version = new Version("6.6");
            var versionString = $"{version.Major}.{version.Minor}";

            var fileBytes = DamageFiles.ContainsKey(versionString)
                                ? DamageFiles[versionString]
                                : DamageFiles.OrderByDescending(o => o.Key).FirstOrDefault().Value;

            if (fileBytes != null)
            {
                CreateDamages(JObject.Parse(Encoding.Default.GetString(fileBytes)));
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the damage collection.
        /// </summary>
        /// <value>
        ///     The damage collection.
        /// </value>
        public IReadOnlyDictionary<string, ChampionDamage> Damage => DamageCollection;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the Damage Collection.
        /// </summary>
        private static Dictionary<string, ChampionDamage> DamageCollection { get; } =
            new Dictionary<string, ChampionDamage>();

        #endregion

        #region Methods

        /// <summary>
        ///     Creates the damages.
        /// </summary>
        /// <param name="damages">The damages.</param>
        private static void CreateDamages(IDictionary<string, JToken> damages)
        {
            foreach (var champion in ObjectManager.Get<Obj_AI_Hero>().Select(h => h.ChampionName).Distinct())
            {
                JToken value;
                if (damages.TryGetValue(champion, out value))
                {
                    DamageCollection.Add(champion, JsonConvert.DeserializeObject<ChampionDamage>(value.ToString()));
                }
            }
        }

        #endregion
    }

    /// <summary>
    ///     The Champion Damage class container.
    /// </summary>
    public class ChampionDamage
    {
        #region Public Properties

        /// <summary>
        ///     Gets the 'E' spell damage classes.
        /// </summary>
        public List<ChampionDamageSpell> E { get; set; }

        /// <summary>
        ///     Gets the 'Q' spell damage classes.
        /// </summary>
        public List<ChampionDamageSpell> Q { get; set; }

        /// <summary>
        ///     Gets the 'R' spell damage classes.
        /// </summary>
        public List<ChampionDamageSpell> R { get; set; }

        /// <summary>
        ///     Gets the 'W' spell damage classes.
        /// </summary>
        public List<ChampionDamageSpell> W { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Resolves the spell damage classes entry through the SpellSlot component.
        /// </summary>
        /// <param name="slot">
        ///     The SpellSlot.
        /// </param>
        /// <returns>
        ///     The spell damage classes of the requested Spell Slot.
        /// </returns>
        public IEnumerable<ChampionDamageSpell> GetSlot(SpellSlot slot)
        {
            switch (slot)
            {
                case SpellSlot.Q:
                    return this.Q;
                case SpellSlot.W:
                    return this.W;
                case SpellSlot.E:
                    return this.E;
                case SpellSlot.R:
                    return this.R;
            }

            return null;
        }

        #endregion
    }

    /// <summary>
    ///     The Champion Damage Spell class container.
    /// </summary>
    public class ChampionDamageSpell
    {
        #region Public Properties

        /// <summary>
        ///     Gets the Spell Data.
        /// </summary>
        public ChampionDamageSpellData SpellData { get; set; }

        /// <summary>
        ///     Gets the Spell Stage.
        /// </summary>
        public DamageStage Stage { get; set; }

        #endregion
    }

    /// <summary>
    ///     The Champion Damage Spell Bonus class container.
    /// </summary>
    public class ChampionDamageSpellBonus
    {
        #region Public Properties

        public List<double> BonusDamageOnMinion { get; set; }

        /// <summary>
        ///     Gets the Damage Percentages.
        /// </summary>
        public List<double> DamagePercentages { get; set; }

        /// <summary>
        ///     Gets the Damage Type.
        /// </summary>
        public DamageType DamageType { get; set; }

        public List<int> MaxDamageOnMinion { get; set; }

        public List<int> MinDamage { get; set; }

        public double ScalePer100Ad { get; set; }

        public double ScalePer100Ap { get; set; }

        public double ScalePer100BonusAd { get; set; }

        /// <summary>
        ///     Gets the Scaling Buff.
        /// </summary>
        public string ScalingBuff { get; set; }

        /// <summary>
        ///     Gets the Scaling Buff Offset.
        /// </summary>
        public int ScalingBuffOffset { get; set; }

        /// <summary>
        ///     Gets the Scaling Buff Target.
        /// </summary>
        public DamageScalingTarget ScalingBuffTarget { get; set; }

        /// <summary>
        ///     Gets the Scaling Target Type.
        /// </summary>
        public DamageScalingTarget ScalingTarget { get; set; }

        /// <summary>
        ///     Gets the Scaling Type.
        /// </summary>
        public DamageScalingType ScalingType { get; set; }

        #endregion
    }

    /// <summary>
    ///     The Champion Damage Spell Data class container.
    /// </summary>
    public class ChampionDamageSpellData
    {
        #region Public Properties

        public List<double> BonusDamageOnMinion { get; set; }

        /// <summary>
        ///     Gets the Bonus Damages.
        /// </summary>
        public List<ChampionDamageSpellBonus> BonusDamages { get; set; }

        /// <summary>
        ///     Gets the Main Damages.
        /// </summary>
        public List<double> Damages { get; set; }

        public List<double> DamagesPerLvl { get; set; }

        /// <summary>
        ///     Gets the Damage Type.
        /// </summary>
        public DamageType DamageType { get; set; }

        public List<int> MaxDamageOnMinion { get; set; }

        public double ScalePerTargetMissHealth { get; set; }

        /// <summary>
        ///     Gets the Scaling Slot.
        /// </summary>
        public SpellSlot ScaleSlot { get; set; } = SpellSlot.Unknown;

        /// <summary>
        ///     Gets the Scaling Buff.
        /// </summary>
        public string ScalingBuff { get; set; }

        /// <summary>
        ///     Gets the Scaling Buff Offset.
        /// </summary>
        public int ScalingBuffOffset { get; set; }

        /// <summary>
        ///     Gets the Scaling Buff Target.
        /// </summary>
        public DamageScalingTarget ScalingBuffTarget { get; set; }

        public SpellEffectType SpellEffectType { get; set; }

        #endregion
    }
}