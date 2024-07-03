using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Coroutines.Runtime.Core
{
    internal static class CoroutineYield
    {
        private static readonly Dictionary<Type, Func<object, ICoroutineYield>> _yieldHandlers =
            new Dictionary<Type, Func<object, ICoroutineYield>>();

        static CoroutineYield()
        {
            foreach (var type in AllTypesDerivedFrom<YieldHandlers>.Types)
            {
                YieldHandlers yieldHandlers = (YieldHandlers)Activator.CreateInstance(type);
                
                foreach (var kv in yieldHandlers.GetYieldHandlers())
                {
                    _yieldHandlers.TryAdd(kv.Key, kv.Value);
                }
            }
        }

        internal static ICoroutineYield Get(IEnumerator routine)
        {
            object current = routine.Current;

            if (current is ICoroutineYield coroutineYield)
            {
                return coroutineYield;
            }
            else
            {
                if (current == null)
                {
                    return new YieldDefault();
                }
                
                Type currentType = current.GetType();

                if (_yieldHandlers.TryGetValue(currentType, out var yieldHandler))
                {
                    return yieldHandler(current);
                }
                else if (current is IEnumerator enumerator)
                {
                    return new YieldRoutine(enumerator);
                }
                else
                {
                    Debug.LogErrorFormat("Unknown or unsupported type: {0}. Available handlers: {1}", currentType, string.Join(", ", _yieldHandlers.Keys));

                    return new YieldDefault();
                }
            }
        }
    }
}