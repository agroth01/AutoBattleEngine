namespace AutoBattleEngine.Core
{
    /// <summary>
    /// An ability trigger is the action that has to be performed, for an example attacking, dying, leveling up or selling a unit.
    /// </summary>
    public enum AbilityTrigger
    {
        /// <summary>
        /// Default value for trigger. Will throw error if this is used.
        /// </summary>
        None,

        /// <summary>
        /// A unit attacks another unit. This will always be the front unit in a team.
        /// Additionally, units that deals damage with their ability will not trigger this.
        /// </summary>
        Attack,

        /// <summary>
        /// This trigger is for when a unit takes damage from any source. This includes abilities.
        /// </summary>
        Hurt,

        /// <summary>
        /// Unit is killed by health reaching 0.
        /// </summary>
        Death,

        /// <summary>
        /// Anytime a unit has been added to a team. This can be both during a battle and in the shop.
        /// For behavior in either the shop or battle exclusively, use either the Purchased or Spawned trigger.
        /// </summary>
        Summon,

        /// <summary>
        /// When a unit is purchased and added to the team. Use this for behavior only in the shop.
        /// </summary>
        Purchased,

        /// <summary>
        /// When a unit is summoned during battle and added to the team. Use this for behavior only in battle.
        /// </summary>
        Spawned,

        /// <summary>
        /// When a unit levels up.
        /// </summary>
        LevelUp,

        /// <summary>
        /// When a unit has a consumable applied to them in the shop.
        /// </summary>
        Consumption,

        /// <summary>
        /// When a unit is sold in the shop.
        /// </summary>
        Sell,

        /// <summary>
        /// Triggered once at the start of a new battle.
        /// </summary>
        BattleStart,

        /// <summary>
        /// Triggered once at the end of a battle when going to shop phase.
        /// </summary>
        ShopEnter
    }
}