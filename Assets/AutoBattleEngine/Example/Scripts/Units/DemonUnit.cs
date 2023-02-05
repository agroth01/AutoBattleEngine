using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoBattleEngine.Core;

namespace AutoBattleEngine.Examples
{
    /// <summary>
    /// A demon unit is a unit that gains attack whenever an ally dies.
    /// </summary>
    public class DemonUnit : Unit
    {
        protected override void SetDefaults()
        {
            Name = "Demon";
            Description = "Gains +(2/4/6) attack whenever an ally is killed.";
            Sprite = Resources.Load<Sprite>("Sprites/demon");

            BaseHealth = new LevelScalingInt(this, 5);
            BaseAttack = new LevelScalingInt(this, 2);
        }

        protected override void SetAbilityActivation(ref AbilityActivationRequirement requirement)
        {
            requirement.Trigger = AbilityTrigger.Death;
            requirement.Subject = AbilityActivationSubject.AnyAllyExclusive;
        }

        protected override void OnAbilityActivated()
        {
            
        }
    }
}