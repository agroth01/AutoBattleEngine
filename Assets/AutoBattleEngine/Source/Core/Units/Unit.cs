using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoBattleEngine.Core
{
    /// <summary>
    /// A unit is the representation of a character in the game. When you want to create a new unit,
    /// you will have to make a new script that inherits from this one.
    /// 
    /// Keep in mind that the unit by itself does not contain logic for either battle nor the shop,
    /// but instead just the information about the unit.
    /// </summary>
    public abstract class Unit
    {
        /// <summary>
        /// The base health of the unit.
        /// </summary>
        public LevelScalingInt BaseHealth { get; protected set; }

        /// <summary>
        /// The base attack of the unit.
        /// </summary>
        public LevelScalingInt BaseAttack { get; protected set; }

        /// <summary>
        /// The name of the unit.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// The descriptor for this unit.
        /// </summary>
        public string Description { get; protected set; }

        /// <summary>
        /// The sprite for the unit. This is not required for the unit to work,
        /// but assuming that you want to show the unit in the game, you can use
        /// this property to keep a sprite tied to the unit.
        /// </summary>
        public Sprite Sprite { get; protected set; }
        
        /// <summary>
        /// The level of the unit.
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// The default amount of health the unit should have before battle.
        /// Combines the base health and any bonus health gained from items or abilities.
        /// </summary>
        public int Health
        {
            get { return BaseHealth.Value + _bonusHealth; }
        }

        /// <summary>
        /// The default attack the unit has before a battle.
        /// Combines the base attack and permanent bonus attack.
        /// </summary>
        public int Attack
        {
            get { return BaseAttack.Value + _bonusAttack; }
        }

        /// <summary>
        /// The team that this unit is a part of.
        /// </summary>
        public Team Team { get; private set; }

        private AbilityActivationRequirement _abilityActivationRequirement = new AbilityActivationRequirement();

        private int _bonusHealth;
        private int _bonusAttack;

        public Unit()
        {
            SetupUnit();
        }

        /// <summary>
        /// Set the value of the bonus health on this unit directly.
        /// This is used by consumables and abilities that permanently
        /// increases the health of the unit, without affecting the base health (for scaling purposes).
        /// </summary>
        /// <param name="newValue"></param>
        public void ModifyBonusHealth(int newValue)
        {
            _bonusHealth = newValue;
        }

        /// <summary>
        /// Set the value of the bonus attack directly.
        /// Used by consumables and abilities that permanently
        /// increase the attack of a unit.
        /// </summary>
        /// <param name="newValue"></param>
        public void ModifyBonusAttack(int newValue)
        {
            _bonusAttack = newValue;
        }

        /// <summary>
        /// Sets this unit as a part of a team.
        /// </summary>
        /// <param name="team"></param>
        public void SetTeam(Team team)
        {
            Team = team;
        }

        #region Virtual methods

        /// <summary>
        /// This is the method to set up the default information about the unit,
        /// such as name, attack, health, level, sprite etc...
        /// </summary>
        protected virtual void SetDefaults()
        {
            
        }

        /// <summary>
        /// This method is used to specify how the ability of the unit should be activated.
        /// An activation requirement has to have a trigger (What action has to be performed),
        /// as well as a subject (Who the action was performed on).
        /// </summary>
        protected virtual void SetAbilityActivation(ref AbilityActivationRequirement requirement)
        {
            
        }

        /// <summary>
        /// Called when the ability activation requirement is met. Use this method to implement
        /// the ability of the unit.
        /// </summary>
        protected virtual void OnAbilityActivated()
        {

        }

        #endregion

        #region Private methods

        /// <summary>
        /// Goes through all setup methods that can be overridden by inheritors.
        /// </summary>
        private void SetupUnit()
        {
            SetDefaults();
            SetAbilityActivation(ref _abilityActivationRequirement);
            SetInternalDefaults();
        }

        /// <summary>
        /// Handles setting up the default values for the unit that does not 
        /// need to be specified in child classes, for ease of use.
        /// Also verifies that the ability activation requirement is set.
        /// </summary>
        private void SetInternalDefaults()
        {
            Level = 1;

            // Verify that the ability activation requirement is set.
            if (_abilityActivationRequirement.Trigger == AbilityTrigger.None)
            {
                Debug.LogError("Ability activation trigger not set for unit " + Name);
            }

            if (_abilityActivationRequirement.Subject == AbilityActivationSubject.None)
            {
                Debug.LogError("Ability activation subject not set for unit " + Name);
            }
        }
        #endregion
    }
}