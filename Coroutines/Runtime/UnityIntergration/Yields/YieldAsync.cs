using Coroutines.Runtime.Core;
using UnityEngine;

namespace Coroutines.Runtime.UnityIntergration
{
    internal class YieldAsync : ICoroutineYield
    {
        private AsyncOperation _asyncOperation;

        public YieldAsync(AsyncOperation asyncOperation)
        {
            _asyncOperation = asyncOperation;
        }

        public bool IsDone()
        {
            return _asyncOperation.isDone;
        }
    }
}