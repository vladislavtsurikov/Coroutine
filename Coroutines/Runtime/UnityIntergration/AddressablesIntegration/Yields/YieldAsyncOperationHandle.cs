#if ADDRESSABLES
using Coroutines.Runtime.Core;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Coroutines.Runtime.UnityIntergration.AddressablesIntegration
{
    internal class YieldAsyncOperationHandle : ICoroutineYield
    {
        private AsyncOperationHandle<SceneInstance> _asyncOperationHandle;

        public YieldAsyncOperationHandle(AsyncOperationHandle<SceneInstance> asyncOperationHandle)
        {
            _asyncOperationHandle = asyncOperationHandle;
        }

        public bool IsDone()
        {
            return _asyncOperationHandle.IsDone;
        }
    }
}
#endif