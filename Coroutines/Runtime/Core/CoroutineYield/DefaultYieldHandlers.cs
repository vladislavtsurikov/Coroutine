using System;
using System.Collections;
using System.Collections.Generic;

namespace Coroutines.Runtime.Core
{
    public class DefaultYieldHandlersTest : YieldHandlers
    {
        public override Dictionary<Type, Func<object, ICoroutineYield>> GetYieldHandlers()
        {
            return new Dictionary<Type, Func<object, ICoroutineYield>>
            {
                { typeof(Coroutine), current => new YieldNestedCoroutine((Coroutine)current) }
            };
        }
    }
}