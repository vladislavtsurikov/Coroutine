using System;
using System.Collections.Generic;
using System.Reflection;
using Coroutines.Runtime.Core;
using UnityEngine;

namespace Coroutines.Runtime.UnityIntergration
{
    public class UnityYieldHandlers : YieldHandlers
    {
        public override Dictionary<Type, Func<object, ICoroutineYield>> GetYieldHandlers()
        {
            return new Dictionary<Type, Func<object, ICoroutineYield>>
            {
                { typeof(WaitForFixedUpdate), _ => new YieldDefault() },
                { typeof(WaitForEndOfFrame), _ => new YieldDefault() },
                { typeof(WaitForSeconds), current => new YieldWaitForSeconds(float.Parse(GetInstanceField(typeof(WaitForSeconds), current, "m_Seconds").ToString())) },
                { typeof(AsyncOperation), current => new YieldAsync((AsyncOperation)current) }
            };
        }
        
        private static object GetInstanceField(Type type, object instance, string fieldName)
        {
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            FieldInfo field = type.GetField(fieldName, bindFlags);
            return field?.GetValue(instance);
        }
    }
}