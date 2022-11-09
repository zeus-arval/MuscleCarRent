﻿using System.Reflection;

namespace MuscleCarRentProject.Aids {
    public static class NonPublicFlagsFor {
        private const BindingFlags p = BindingFlags.NonPublic;
        private const BindingFlags i = BindingFlags.Instance;
        private const BindingFlags s = BindingFlags.Static;
        private const BindingFlags d = BindingFlags.DeclaredOnly;
        public const BindingFlags All = p | i | s;
        public const BindingFlags Instance = p | i;
        public const BindingFlags Static = p | s;
        public const BindingFlags Declared = p | d | i | s; 
    }
}
