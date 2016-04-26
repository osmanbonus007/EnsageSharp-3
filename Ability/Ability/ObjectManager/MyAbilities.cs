﻿namespace Ability.ObjectManager
{
    using System.Collections.Generic;

    using Ensage;

    internal class MyAbilities
    {
        #region Static Fields

        public static Ability Blink;

        public static Ability ChargeOfDarkness;

        public static IEnumerable<KeyValuePair<string, Ability>> Combo = new Dictionary<string, Ability>();

        public static Ability Cyclone;

        public static Dictionary<string, Ability> DeffensiveAbilities;

        public static Ability ForceStaff;

        public static List<Ability> NukesCombo = new List<Ability>();

        /// <summary>
        /// The offensive abilities.
        /// </summary>
        public static Dictionary<string, Ability> OffensiveAbilities;

        public static Ability PowerTreads;

        public static Ability SoulRing;

        public static Ability TinkerRearm;

        #endregion
    }
}