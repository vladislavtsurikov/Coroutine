using System;
using System.Collections.Generic;
using System.Linq;

namespace Coroutines.Runtime.Core
{
    public static class AllTypesDerivedFrom<T>
    {
        public static readonly Type[] Types;

        static AllTypesDerivedFrom()
        {
            var types = GetAllAssemblyTypes().Where(t => t.IsSubclassOf(typeof(T)));

            Types = types.ToArray();
        }
        
        private static IEnumerable<Type> GetAllAssemblyTypes()
        {
            IEnumerable<Type> assemblyTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes());

            return assemblyTypes;
        }
    }
}