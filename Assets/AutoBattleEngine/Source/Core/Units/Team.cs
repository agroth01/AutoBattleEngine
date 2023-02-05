using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoBattleEngine.Core
{
    /// <summary>
    /// A team is a collection of units. The position of a unit in the team directly
    /// correlates to it's position on the battlefield. So if a unit is at index 0, it
    /// will be counted as in the front.
    /// </summary>
    public class Team : UnitCollection
    {
        /// <summary>
        /// Creates a new team of the given size.
        /// </summary>
        /// <param name="teamSize">Size of the team.</param>
        public Team(int teamSize) : base(teamSize)
        {
            
        }

        #region Team management

        /// <summary>
        /// Attempts to add a unit to the team. Will fail if the team is full.
        /// Automatically sets the unit's team to this team.
        /// </summary>
        /// <param name="unit">The unit to add.</param>
        public void AddUnit(Unit unit)
        {
            if (IsFull())
                return;

            int position = GetFirstAvailablePosition();
            SetUnit(position, unit);

            unit.SetTeam(this);
        }

        /// <summary>
        /// Removes a unit from the team. Will fail if the unit is not in the team.
        /// </summary>
        /// <param name="unit">The unit to remove.</param>
        public void RemoveUnit(Unit unit)
        {
            if (ContainsUnit(unit))
            {
                int position = GetUnitPosition(unit);
                SetUnit(position, null);
            }

            unit.SetTeam(null);
        }

        /// <summary>
        /// Remove a unit by it's position in the team.
        /// </summary>
        /// <param name="positionIndex">Index of the unit.</param>
        public void RemoveUnit(int positionIndex)
        {
            SetUnit(positionIndex, null);
        }

        #endregion
    }
}
