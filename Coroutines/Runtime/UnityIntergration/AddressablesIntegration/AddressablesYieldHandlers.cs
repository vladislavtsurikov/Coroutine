#if ADDRESSABLES
using System;
using System.Collections.Generic;
using Coroutines.Runtime.Core;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Coroutines.Runtime.UnityIntergration.AddressablesIntegration
{
    public class AddressablesYieldHandlers : YieldHandlers
    {
        public override Dictionary<Type, Func<object, ICoroutineYield>> GetYieldHandlers()
        {
            return new Dictionary<Type, Func<object, ICoroutineYield>>
            {
                { typeof(AsyncOperationHandle<SceneInstance>), current => new YieldAsyncOperationHandle((AsyncOperationHandle<SceneInstance>)current) },
            };
        }
    }
}
#endif