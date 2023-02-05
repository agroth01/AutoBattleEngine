using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoBattleEngine.Core
{
    /// <summary>
    /// A battle unit is a unit that is currently in a battle.
    /// 
    /// By providing a base unit, this will extend it's behaviour to include
    /// combat related actions.
    /// </summary>
    public class BattleUnit : Unit
    {
        private Unit _base;

        public BattleUnit(Unit baseUnit)
        {
            _base = baseUnit;
        }
    }
}
    
