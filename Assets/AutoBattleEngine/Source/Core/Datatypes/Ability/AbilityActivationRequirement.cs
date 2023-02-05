namespace AutoBattleEngine.Core
{
    /// <summary>
    /// Each unit has it's own requirements to activate their ability.
    /// 
    /// This consists of a trigger and a subject.
    /// A trigger is the action that has to be performed, for an example attacking, dying, leveling up or selling a unit.
    /// The subject of the requirement is the unit that has to experience the trigger.
    /// </summary>
    public struct AbilityActivationRequirement
    {
        public AbilityTrigger Trigger;
        public AbilityActivationSubject Subject;
    }
}