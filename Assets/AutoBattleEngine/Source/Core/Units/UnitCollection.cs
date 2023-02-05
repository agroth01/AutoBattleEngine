using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoBattleEngine.Core
{
    /// <summary>
    /// The base class for any grouping of units. Used in order to differentiate between a shop selection and
    /// a team.
    /// </summary>
    public abstract class UnitCollection
    {
        private Unit[] _members;

        /// <summary>
        /// Creates a new unit collection of the given size.
        /// </summary>
        /// <param name="size">Positive integer for size of collection.</param>
        public UnitCollection(int size)
        {
            _members = new Unit[size];
        }

        #region Getters

        #endregion

        #region Retrieval

        /// <summary>
        /// Retrieves the unit at the given position.
        /// Returns null if no unit is present.
        /// </summary>
        /// <param name="positionIndex">Positive integer representing position in team.</param>
        /// <returns>Instance of unit at position.</returns>
        public Unit GetUnit(int positionIndex)
        {
            return _members[positionIndex];
        }

        /// <summary>
        /// Returns the position index of a unit in the collection.
        /// Will return -1 in cases where the unit is not in the collection..
        /// </summary>
        /// <param name="unit">The unit to get position of.</param>
        /// <returns>An integer representing the index.</returns>
        public int GetUnitPosition(Unit unit)
        {
            for (int i = 0; i < _members.Length; i++)
            {
                if (_members[i] == unit)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Check if the collection contains an instance of the given unit.
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public bool ContainsUnit(Unit unit)
        {
            return GetUnitPosition(unit) != -1;
        }

        #endregion

        #region Collection management

        /// <summary>
        /// Sets the given unit at the given index.
        /// </summary>
        /// <param name="idx">Positional index</param>
        /// <param name="unit">The unit to set.</param>
        protected void SetUnit(int idx, Unit unit)
        {
            _members[idx] = unit;
        }

        /// <summary>
        /// Determines if the collection is full.
        /// </summary>
        /// <returns></returns>
        protected bool IsFull()
        {
            bool full = false;

            for (int i = 0; i < _members.Length; i++)
            {
                if (_members[i] == null)
                {
                    full = false;
                    break;
                }
                else
                {
                    full = true;
                }
            }

            return full;
        }

        /// <summary>
        /// Find the first position index that is available.
        /// </summary>
        /// <returns></returns>
        protected int GetFirstAvailablePosition()
        {
            for (int i = 0; i < _members.Length; i++)
            {
                if (_members[i] == null)
                {
                    return i;
                }
            }

            return -1;
        }

        #endregion
    }
}