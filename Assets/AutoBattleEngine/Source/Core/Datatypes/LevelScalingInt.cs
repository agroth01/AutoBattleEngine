using UnityEngine;

namespace AutoBattleEngine.Core
{
    /// <summary>
    /// Since a lot of values in the game scaled with levels, this class is used when you want to
    /// have a value that scales with levels.
    /// 
    /// By passing in a reference to the unit when constructing an instance of this class, you can
    /// automatically get the appropriate value by calling the Value property.
    /// </summary>
    public class LevelScalingInt
    {
        private Unit _unit;
        private int _baseValue;

        /// <summary>
        /// The value of the level scaling int.
        /// </summary>
        public int Value
        {
            get { return DetermineValue(); }
        }

        /// <summary>
        /// Create a new instance of the level scaling int.
        /// 
        /// Will automatically determine the value of the level scaling int based on the unit's level.
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="baseValue"></param>
        public LevelScalingInt(Unit unit, int baseValue)
        {
            _unit = unit;
            _baseValue = baseValue;
        }

        /// <summary>
        /// Determines the value of the level scaling int based on the unit's level.
        /// 
        /// Will only scale the value if the level is greater than 1, otherwise the 
        /// base value will be used.
        /// </summary>
        /// <returns></returns>
        private int DetermineValue()
        {
            return (_unit.Level > 1) ? _baseValue + (_baseValue * (_unit.Level - 1)) : _baseValue;
        }
    }

}