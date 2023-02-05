namespace AutoBattleEngine.Core
{
    /// <summary>
    /// The subject of the requirement is the unit that has to experience the trigger. Will be used together with a reference unit
    /// to base the subject on. The reference unit is the unit that is activating the ability.
    /// 
    /// Note that while this shares a lot of the same values as AbilityTarget, it is not the same.
    /// Most notably, this does not contain random units for an example.
    /// </summary>
    public enum AbilityActivationSubject
    {
        /// <summary>
        /// Default value for subject, will throw error if this is used.
        /// </summary>
        None,

        /// <summary>
        /// The unit that is activating the ability.
        /// </summary>
        Self,
        
        /// <summary>
        /// Any unit currently in the game EXCLUDING the unit that is activating the ability.
        /// This can be any unit from both the ally and opponent team.
        /// </summary>
        AnyExclusive,

        /// <summary>
        /// Any unit currently in the game INCLUDING the unit that is activating the ability.
        /// This can be any unit from both the ally and opponent team.
        /// </summary>
        AnyInclusive,

        /// <summary>
        /// Any of the units on the ally team of the unit, EXCLUDING the unit that is activating the ability.
        /// </summary>
        AnyAllyExclusive,

        /// <summary>
        /// Any of the units on the ally team of the unit, INCLUDING the unit that is activating the ability.
        /// </summary>
        AnyAllyInclusive,

        /// <summary>
        /// Any of the units on the opponent team.
        /// </summary>
        AnyOpponent,

        /// <summary>
        /// The first unit on the ally team of the unit that is activating the ability.
        /// </summary>
        FirstAlly,

        /// <summary>
        /// The ally that is in front of the unit that is activating the ability.
        /// </summary>
        FrontAlly,

        /// <summary>
        /// The ally that is behind the unit that is activating the ability.
        /// </summary>
        BackAlly,
    }
}