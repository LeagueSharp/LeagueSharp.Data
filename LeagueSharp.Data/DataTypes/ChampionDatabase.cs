namespace LeagueSharp.Data.DataTypes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class ChampionDatabase : DataType
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Prevents a default instance of the <see cref="ChampionDatabase" /> class from being created.
        /// </summary>
        private ChampionDatabase()
        {
            // TODO get game version + add json files as resources
            var webclient = new WebClient();
            var championsJson =
                JObject.Parse(
                    webclient.DownloadString("http://ddragon.leagueoflegends.com/cdn/6.7.1/data/en_US/champion.json"))[
                        "data"].Value<JObject>();

            foreach (var champion in championsJson)
            {
                this.ChampionList.Add(champion.Key);
            }

            foreach (var champion in this.Champions)
            {
                var championObj =
                    JObject.Parse(
                        webclient.DownloadString(
                            $"http://ddragon.leagueoflegends.com/cdn/6.7.1/data/en_US/champion/{champion}.json"));

                this.ChampionDataList.Add(championObj["data"][champion].ToObject<ChampionDatabaseEntry>());
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the champion data.
        /// </summary>
        /// <value>
        ///     The champion data.
        /// </value>
        public IReadOnlyList<ChampionDatabaseEntry> ChampionData => this.ChampionDataList;

        /// <summary>
        ///     Gets the champions.
        /// </summary>
        /// <value>
        ///     The champions.
        /// </value>
        public IReadOnlyList<string> Champions => this.ChampionList;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the champion data list.
        /// </summary>
        /// <value>
        ///     The champion data list.
        /// </value>
        private List<ChampionDatabaseEntry> ChampionDataList { get; } = new List<ChampionDatabaseEntry>();

        /// <summary>
        ///     Gets the champion list.
        /// </summary>
        /// <value>
        ///     The champion list.
        /// </value>
        private List<string> ChampionList { get; } = new List<string>();

        #endregion

        #region Public Indexers

        /// <summary>
        ///     Gets the <see cref="ChampionDatabaseEntry" /> with the specified champion.
        /// </summary>
        /// <value>
        ///     The <see cref="ChampionDatabaseEntry" />.
        /// </value>
        /// <param name="champion">The champion.</param>
        /// <returns></returns>
        public ChampionDatabaseEntry this[string champion]
        {
            get
            {
                return
                    this.ChampionDataList.FirstOrDefault(
                        x => x.Name.Equals(champion, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        #endregion
    }

    public class Image
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the full.
        /// </summary>
        /// <value>
        ///     The full.
        /// </value>
        [JsonProperty("full")]
        public string Full { get; set; }

        /// <summary>
        ///     Gets or sets the group.
        /// </summary>
        /// <value>
        ///     The group.
        /// </value>
        [JsonProperty("group")]
        public string Group { get; set; }

        /// <summary>
        /// </summary>
        /// <value>
        ///     The height.
        /// </value>
        [JsonProperty("h")]
        public int H { get; set; }

        /// <summary>
        ///     Gets or sets the sprite.
        /// </summary>
        /// <value>
        ///     The sprite.
        /// </value>
        [JsonProperty("sprite")]
        public string Sprite { get; set; }

        /// <summary>
        /// </summary>
        /// <value>
        ///     The width.
        /// </value>
        [JsonProperty("w")]
        public int W { get; set; }

        /// <summary>
        /// </summary>
        /// <value>
        ///     The x position.
        /// </value>
        [JsonProperty("x")]
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the y positon.
        /// </summary>
        /// <value>
        ///     The y position.
        /// </value>
        [JsonProperty("y")]
        public int Y { get; set; }

        #endregion
    }

    public class Skin
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="Skin" /> has chromas.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this <see cref="Skin" /> has chromas; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("chromas")]
        public bool Chromas { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>
        ///     The number.
        /// </value>
        [JsonProperty("num")]
        public int Number { get; set; }

        #endregion
    }

    public class Info
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the attack.
        /// </summary>
        /// <value>
        ///     The attack.
        /// </value>
        [JsonProperty("attack")]
        public int Attack { get; set; }

        /// <summary>
        ///     Gets or sets the defense.
        /// </summary>
        /// <value>
        ///     The defense.
        /// </value>
        [JsonProperty("defense")]
        public int Defense { get; set; }

        /// <summary>
        ///     Gets or sets the difficulty.
        /// </summary>
        /// <value>
        ///     The difficulty.
        /// </value>
        [JsonProperty("difficulty")]
        public int Difficulty { get; set; }

        /// <summary>
        ///     Gets or sets the magic.
        /// </summary>
        /// <value>
        ///     The magic.
        /// </value>
        [JsonProperty("magic")]
        public int Magic { get; set; }

        #endregion
    }

    public class Stats
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the armor.
        /// </summary>
        /// <value>
        ///     The armor.
        /// </value>
        [JsonProperty("armor")]
        public double Armor { get; set; }

        /// <summary>
        ///     Gets or sets the armor per level.
        /// </summary>
        /// <value>
        ///     The armor per level.
        /// </value>
        [JsonProperty("armorperlevel")]
        public double ArmorPerLevel { get; set; }

        /// <summary>
        ///     Gets or sets the attack damage.
        /// </summary>
        /// <value>
        ///     The attack damage.
        /// </value>
        [JsonProperty("attackdamage")]
        public double AttackDamage { get; set; }

        /// <summary>
        ///     Gets or sets the attack damage per level.
        /// </summary>
        /// <value>
        ///     The attack damage per level.
        /// </value>
        [JsonProperty("attackdamageperlevel")]
        public double AttackDamagePerLevel { get; set; }

        /// <summary>
        ///     Gets or sets the attack range.
        /// </summary>
        /// <value>
        ///     The attack range.
        /// </value>
        [JsonProperty("attackrange")]
        public double AttackRange { get; set; }

        /// <summary>
        ///     Gets or sets the attack speed offset.
        /// </summary>
        /// <value>
        ///     The attack speed offset.
        /// </value>
        [JsonProperty("attackspeedoffset")]
        public double AttackSpeedOffset { get; set; }

        /// <summary>
        ///     Gets or sets the attack speed per level.
        /// </summary>
        /// <value>
        ///     The attack speed per level.
        /// </value>
        [JsonProperty("attackspeedperlevel")]
        public double AttackSpeedPerLevel { get; set; }

        /// <summary>
        ///     Gets or sets the crit.
        /// </summary>
        /// <value>
        ///     The crit.
        /// </value>
        [JsonProperty("crit")]
        public double Crit { get; set; }

        /// <summary>
        ///     Gets or sets the crit per level.
        /// </summary>
        /// <value>
        ///     The crit per level.
        /// </value>
        [JsonProperty("critperlevel")]
        public double CritPerLevel { get; set; }

        /// <summary>
        /// </summary>
        /// <value>
        ///     The hp.
        /// </value>
        [JsonProperty("hp")]
        public double Hp { get; set; }

        /// <summary>
        ///     Gets or sets the hp per level.
        /// </summary>
        /// <value>
        ///     The hp per level.
        /// </value>
        [JsonProperty("hpperlevel")]
        public double HpPerLevel { get; set; }

        /// <summary>
        ///     Gets or sets the hp regen.
        /// </summary>
        /// <value>
        ///     The hp regen.
        /// </value>
        [JsonProperty("hpregen")]
        public double HpRegen { get; set; }

        /// <summary>
        ///     Gets or sets the hp regen per level.
        /// </summary>
        /// <value>
        ///     The hp regen per level.
        /// </value>
        [JsonProperty("hpregenperlevel")]
        public double HpRegenPerLevel { get; set; }

        /// <summary>
        ///     Gets or sets the move speed.
        /// </summary>
        /// <value>
        ///     The move speed.
        /// </value>
        [JsonProperty("movespeed")]
        public double MoveSpeed { get; set; }

        /// <summary>
        /// </summary>
        /// <value>
        ///     The mp.
        /// </value>
        [JsonProperty("mp")]
        public double Mp { get; set; }

        /// <summary>
        ///     Gets or sets the mp per level.
        /// </summary>
        /// <value>
        ///     The mp per level.
        /// </value>
        [JsonProperty("mpperlevel")]
        public double MpPerLevel { get; set; }

        /// <summary>
        ///     Gets or sets the mp regen.
        /// </summary>
        /// <value>
        ///     The mp regen.
        /// </value>
        [JsonProperty("mpregen")]
        public double MpRegen { get; set; }

        /// <summary>
        ///     Gets or sets the mp regen per level.
        /// </summary>
        /// <value>
        ///     The mp regen per level.
        /// </value>
        [JsonProperty("mpregenperlevel")]
        public double MpRegenPerLevel { get; set; }

        /// <summary>
        ///     Gets or sets the spell block.
        /// </summary>
        /// <value>
        ///     The spell block.
        /// </value>
        [JsonProperty("spellblock")]
        public double SpellBlock { get; set; }

        /// <summary>
        ///     Gets or sets the spell block per level.
        /// </summary>
        /// <value>
        ///     The spell block per level.
        /// </value>
        [JsonProperty("spellblockperlevel")]
        public double SpellBlockPerLevel { get; set; }

        #endregion
    }

    public class LevelTip
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the effect.
        /// </summary>
        /// <value>
        ///     The effect.
        /// </value>
        [JsonProperty("effect")]
        public IList<string> Effect { get; set; }

        /// <summary>
        ///     Gets or sets the label.
        /// </summary>
        /// <value>
        ///     The label.
        /// </value>
        [JsonProperty("label")]
        public IList<string> Label { get; set; }

        #endregion
    }

    public class Var
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the coeff.
        /// </summary>
        /// <value>
        ///     The coeff.
        /// </value>
        [JsonProperty("coeff")]
        public dynamic Coeff { get; set; }

        /// <summary>
        ///     Gets or sets the key.
        /// </summary>
        /// <value>
        ///     The key.
        /// </value>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        ///     Gets or sets the link.
        /// </summary>
        /// <value>
        ///     The link.
        /// </value>
        [JsonProperty("link")]
        public string Link { get; set; }

        #endregion
    }

    public class Spell
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the cooldown.
        /// </summary>
        /// <value>
        ///     The cooldown.
        /// </value>
        [JsonProperty("cooldown")]
        public IList<double> Cooldown { get; set; }

        /// <summary>
        ///     Gets or sets the cooldown burn.
        /// </summary>
        /// <value>
        ///     The cooldown burn.
        /// </value>
        [JsonProperty("cooldownBurn")]
        public string CooldownBurn { get; set; }

        /// <summary>
        ///     Gets or sets the cost.
        /// </summary>
        /// <value>
        ///     The cost.
        /// </value>
        [JsonProperty("cost")]
        public IList<int> Cost { get; set; }

        /// <summary>
        ///     Gets or sets the cost burn.
        /// </summary>
        /// <value>
        ///     The cost burn.
        /// </value>
        [JsonProperty("costBurn")]
        public string CostBurn { get; set; }

        /// <summary>
        ///     Gets or sets the type of the cost.
        /// </summary>
        /// <value>
        ///     The type of the cost.
        /// </value>
        [JsonProperty("costType")]
        public string CostType { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the effect.
        /// </summary>
        /// <value>
        ///     The effect.
        /// </value>
        [JsonProperty("effect")]
        public IList<IList<double>> Effect { get; set; }

        /// <summary>
        ///     Gets or sets the effect burn.
        /// </summary>
        /// <value>
        ///     The effect burn.
        /// </value>
        [JsonProperty("effectBurn")]
        public IList<string> EffectBurn { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the image.
        /// </summary>
        /// <value>
        ///     The image.
        /// </value>
        [JsonProperty("image")]
        public Image Image { get; set; }

        /// <summary>
        ///     Gets or sets the level tip.
        /// </summary>
        /// <value>
        ///     The level tip.
        /// </value>
        [JsonProperty("leveltip")]
        public LevelTip LevelTip { get; set; }

        /// <summary>
        ///     Gets or sets the maximum ammo.
        /// </summary>
        /// <value>
        ///     The maximum ammo.
        /// </value>
        [JsonProperty("maxammo")]
        public string MaxAmmo { get; set; }

        /// <summary>
        ///     Gets or sets the maximum rank.
        /// </summary>
        /// <value>
        ///     The maximum rank.
        /// </value>
        [JsonProperty("maxrank")]
        public int MaxRank { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the range.
        /// </summary>
        /// <value>
        ///     The range.
        /// </value>
        [JsonProperty("range")]
        public IList<int> Range { get; set; }

        /// <summary>
        ///     Gets or sets the range burn.
        /// </summary>
        /// <value>
        ///     The range burn.
        /// </value>
        [JsonProperty("rangeBurn")]
        public string RangeBurn { get; set; }

        /// <summary>
        ///     Gets or sets the resource.
        /// </summary>
        /// <value>
        ///     The resource.
        /// </value>
        [JsonProperty("resource")]
        public string Resource { get; set; }

        /// <summary>
        ///     Gets or sets the tool tip.
        /// </summary>
        /// <value>
        ///     The tool tip.
        /// </value>
        [JsonProperty("tooltip")]
        public string ToolTip { get; set; }

        /// <summary>
        ///     Gets or sets the vars.
        /// </summary>
        /// <value>
        ///     The vars.
        /// </value>
        [JsonProperty("vars")]
        public IList<Var> Vars { get; set; }

        #endregion
    }

    public class Passive
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the image.
        /// </summary>
        /// <value>
        ///     The image.
        /// </value>
        [JsonProperty("image")]
        public Image Image { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        #endregion
    }

    public class Item
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the number of times this item should be purchased. The count is displayed in the bottom right of the
        ///     item icon. The indicator counts down whenever the item is purchased. If the count reaches 0 the item will show a
        ///     check mark indicating the item has been completed. Defaults to 0.t.
        /// </summary>
        /// <value>
        ///     The number of times this item should be purchased.
        /// </value>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [hide count].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [hide count]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("hideCount")]
        public bool HideCount { get; set; }

        /// <summary>
        ///     Gets or sets the item id as a string, e.g. "1001".
        /// </summary>
        /// <value>
        ///     The item id.
        /// </value>
        [JsonProperty("id")]
        public string Id { get; set; }

        #endregion
    }

    public class Block
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the spell to hide the block if the player has the spell equipped. Can be any valid summoner spell key,
        ///     e.g. SummonerDot. Defaults to an empty string. Overrides showIfSummonerSpell.
        /// </summary>
        /// <value>
        ///     The hide if summoner spell.
        /// </value>
        [JsonProperty("hideIfSummonerSpell")]
        public string HideIfSummonerSpell { get; set; }

        /// <summary>
        ///     Gets or sets an array of items to be displayed within the block.
        /// </summary>
        /// <value>
        ///     The items.
        /// </value>
        [JsonProperty("items")]
        public IList<Item> Items { get; set; }

        /// <summary>
        ///     Gets or sets the maximum allowed account level for the block to be visible to the player. Defaults to -1 which is
        ///     equivalent to "any account level."
        /// </summary>
        /// <value>
        ///     The maximum summoner level.
        /// </value>
        [JsonProperty("maxSummonerLevel")]
        public int MaxSummonerLevel { get; set; }

        /// <summary>
        ///     Gets or sets the minimum required account level for the block to be visible to the player. Defaults to -1 which is
        ///     equivalent to "any account level."
        /// </summary>
        /// <value>
        ///     The minimum summoner level.
        /// </value>
        [JsonProperty("minSummonerLevel")]
        public int MinSummonerLevel { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether or not to use the tutorial formatting when displaying items in the block.
        ///     All items within the block are separated by a plus sign with the last item being separated by an arrow indicating
        ///     that the other items build into the last item. Defaults to false.
        /// </summary>
        /// <value>
        ///     <c>true</c> if using tutorial formatting; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("recMath")]
        public bool RecMath { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether or not to record steps.
        /// </summary>
        /// <value>
        ///     <c>true</c> if recording steps; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("recSteps")]
        public bool RecSteps { get; set; }

        /// <summary>
        ///     Gets or sets the spell to only show if the block if the player has equipped it. Can be any valid summoner spell
        ///     key, e.g. SummonerDot. Defaults to an empty string. Will not override hideIfSummonerSpell.
        /// </summary>
        /// <value>
        ///     The show if summoner spell.
        /// </value>
        [JsonProperty("showIfSummonerSpell")]
        public string ShowIfSummonerSpell { get; set; }

        /// <summary>
        ///     Gets or sets the name of the block as you would see it in the item set.
        /// </summary>
        /// <value>
        ///     The name of the block as you would see it in the item set.
        /// </value>
        [JsonProperty("type")]
        public string Type { get; set; }

        #endregion
    }

    /// <summary>
    /// </summary>
    public class Recommended
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the sections within an item set.
        /// </summary>
        /// <value>
        ///     The blocks.
        /// </value>
        [JsonProperty("blocks")]
        public IList<Block> Blocks { get; set; }

        /// <summary>
        ///     Gets or sets the champion.
        /// </summary>
        /// <value>
        ///     The champion.
        /// </value>
        [JsonProperty("champion")]
        public string Champion { get; set; }

        /// <summary>
        ///     Gets or sets the custom panel.
        /// </summary>
        /// <value>
        ///     The custom panel.
        /// </value>
        [JsonProperty("customPanel")]
        public object CustomPanel { get; set; }

        /// <summary>
        ///     Gets or sets the custom tag.
        /// </summary>
        /// <value>
        ///     The custom tag.
        /// </value>
        [JsonProperty("customTag")]
        public string CustomTag { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the page is an extension.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the page is an extension; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("extensionPage")]
        public bool ExtensionPage { get; set; }

        /// <summary>
        ///     Gets or sets the map this item set will appear on. Can be any, Summoner's Rift SR, Howling Abyss HA, Twisted
        ///     Treeline TT, or Crystal Scar CS.
        /// </summary>
        /// <value>
        ///     The map this item set will appear on.
        /// </value>
        [JsonProperty("map")]
        public string Map { get; set; }

        /// <summary>
        ///     Gets or sets the mode this item set will appear on. Can be any, CLASSIC, ARAM, or Dominion ODIN.
        /// </summary>
        /// <value>
        ///     The mode this item set will appear on.
        /// </value>
        [JsonProperty("mode")]
        public string Mode { get; set; }

        /// <summary>
        ///     Gets or sets the title. This is the name of the item set as you would see it in the drop down.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the type. Can be custom or global. This field is only used for grouping and sorting item sets. Custom
        ///     item sets are ordered above global item sets. This field does not govern whether an item set available for every
        ///     champion.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        [JsonProperty("type")]
        public string Type { get; set; }

        #endregion
    }

    public class ChampionDatabaseEntry
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the ally tips.
        /// </summary>
        /// <value>
        ///     The ally tips.
        /// </value>
        [JsonProperty("allytips")]
        public IList<string> AllyTips { get; set; }

        /// <summary>
        ///     Gets or sets the blurb.
        /// </summary>
        /// <value>
        ///     The blurb.
        /// </value>
        [JsonProperty("blurb")]
        public string Blurb { get; set; }

        /// <summary>
        ///     Gets or sets the enemy tips.
        /// </summary>
        /// <value>
        ///     The enemy tips.
        /// </value>
        [JsonProperty("enemytips")]
        public IList<string> EnemyTips { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the image.
        /// </summary>
        /// <value>
        ///     The image.
        /// </value>
        [JsonProperty("image")]
        public Image Image { get; set; }

        /// <summary>
        ///     Gets or sets the information.
        /// </summary>
        /// <value>
        ///     The information.
        /// </value>
        [JsonProperty("info")]
        public Info Info { get; set; }

        /// <summary>
        ///     Gets or sets the key.
        /// </summary>
        /// <value>
        ///     The key.
        /// </value>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        ///     Gets or sets the lore.
        /// </summary>
        /// <value>
        ///     The lore.
        /// </value>
        [JsonProperty("lore")]
        public string Lore { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the partype.
        /// </summary>
        /// <value>
        ///     The partype.
        /// </value>
        [JsonProperty("partype")]
        public string ParType { get; set; }

        /// <summary>
        ///     Gets or sets the passive.
        /// </summary>
        /// <value>
        ///     The passive.
        /// </value>
        [JsonProperty("passive")]
        public Passive Passive { get; set; }

        /// <summary>
        ///     Gets or sets the recommended.
        /// </summary>
        /// <value>
        ///     The recommended.
        /// </value>
        [JsonProperty("recommended")]
        public IList<Recommended> Recommended { get; set; }

        /// <summary>
        ///     Gets or sets the skins.
        /// </summary>
        /// <value>
        ///     The skins.
        /// </value>
        [JsonProperty("skins")]
        public IList<Skin> Skins { get; set; }

        /// <summary>
        ///     Gets or sets the spells.
        /// </summary>
        /// <value>
        ///     The spells.
        /// </value>
        [JsonProperty("spells")]
        public IList<Spell> Spells { get; set; }

        /// <summary>
        ///     Gets or sets the stats.
        /// </summary>
        /// <value>
        ///     The stats.
        /// </value>
        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        /// <summary>
        ///     Gets or sets the tags.
        /// </summary>
        /// <value>
        ///     The tags.
        /// </value>
        [JsonProperty("tags")]
        public IList<string> Tags { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        [JsonProperty("title")]
        public string Title { get; set; }

        #endregion
    }
}