﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MuscleCarRentProject.Aids {
    public static class GetSolution {
        public static AppDomain Domain => AppDomain.CurrentDomain;
        public static List<Assembly> Assemblies =>
            Safe.Run(() => Domain.GetAssemblies().ToList(),
                new List<Assembly>());
        public static List<Assembly> ReferenceAssemblies(string assemblyName) =>
            Safe.Run(() => {
                var a = AssemblyByName(assemblyName);
                var assemblies = a.GetReferencedAssemblies();
                var l = assemblies.Select(Assembly.Load).ToList();
                return l;
            }, new List<Assembly>());
        public static Assembly AssemblyByName(string name) 
            => Safe.Run(() => Assembly.Load(name), null);
        public static List<Type> TypesForAssembly(string assemblyName) 
            => Safe.Run(() => AssemblyByName(assemblyName).GetTypes().ToList()
                , new List<Type>());
        public static List<string> TypeNamesForAssembly(string assemblyName) 
           => Safe.Run(() => TypesForAssembly(assemblyName).Select(t => t.FullName).ToList()
               , new List<string>());
        public static string Name =>
            GetClass.Namespace(typeof(GetSolution)).GetHead();
    }
}
