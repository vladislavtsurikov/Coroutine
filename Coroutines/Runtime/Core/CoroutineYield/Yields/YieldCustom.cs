using System;

namespace Coroutines.Runtime.Core
{
    public class YieldCustom : ICoroutineYield
    {
        private readonly Func<bool> _isDoneFunction;

        public YieldCustom(Func<bool> isDoneFunction)
        {
            _isDoneFunction = isDoneFunction;
        }

        public bool IsDone()
        {
            return _isDoneFunction.Invoke();
        }
    }
}