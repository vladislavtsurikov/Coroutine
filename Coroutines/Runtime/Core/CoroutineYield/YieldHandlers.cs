using System;
using System.Collections.Generic;

namespace Coroutines.Runtime.Core
{
    public abstract class YieldHandlers
    {
        public abstract Dictionary<Type, Func<object, ICoroutineYield>> GetYieldHandlers();
    }
}