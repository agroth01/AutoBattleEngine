using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoBattleEngine.Core;

namespace AutoBattleEngine.Examples
{
    public class BattleScene : MonoBehaviour
    {
        private void Start()
        {
            DemonUnit demon = UnitRegistry.CreateUnit<DemonUnit>();
            Debug.Log(demon.Name);
        }
    }

}