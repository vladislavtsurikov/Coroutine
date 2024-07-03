using System.Collections;

namespace Coroutines.Runtime.Core
{
    internal class YieldRoutine : ICoroutineYield
    {
        private Coroutine _coroutine;

        public YieldRoutine(IEnumerator enumerator)
        {
            _coroutine = new Coroutine(enumerator);
        }

        public bool IsDone()
        {
            if (!_coroutine.MoveNext())
            {
                _coroutine.Finished = true;
                return true;
            }

            return false;
        }
    }
}