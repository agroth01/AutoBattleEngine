using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoBattleEngine.Core
{
    /// <summary>
    /// This is the registry of all units in the game. It uses reflection to find all the units in the
    /// game on start-up. Provides methods for creating new instances of units.
    /// </summary>
    public static class UnitRegistry
    {
        private static readonly Dictionary<string, Func<Unit>> _unitRegister = new Dictionary<string, Func<Unit>>();

        /// <summary>
        /// Static constructor for the unit registry. This will find all the units in the game and
        /// add them to the register.
        /// </summary>
        static UnitRegistry()
        {
            Type unitType = typeof(Unit);
            IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => unitType.IsAssignableFrom(p) && !p.IsAbstract);

            foreach (Type type in types)
            {
                _unitRegister.Add(type.Name, () => (Unit)Activator.CreateInstance(type));
            }
        }

        /// <summary>
        /// Creates a new instance of a unit with the given type.
        /// </summary>
        /// <typeparam name="T">The type of unit to create.</typeparam>
        /// <returns>A new instance of the unit.</returns>
        public static T CreateUnit<T>() where T : Unit
        {
            return (T)_unitRegister[typeof(T).Name]();
        }

        /// <summary>
        /// Returns a list of all units in the game.
        /// </summary>
        /// <returns></returns>
        public static List<Unit> GetAllUnits()
        {
            return _unitRegister.Values.Select(x => x()).ToList();
        }
    }
}
