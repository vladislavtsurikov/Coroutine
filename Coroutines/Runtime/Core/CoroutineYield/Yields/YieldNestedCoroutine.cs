namespace Coroutines.Runtime.Core
{
    internal class YieldNestedCoroutine : ICoroutineYield
    {
        private Coroutine _coroutine;

        public YieldNestedCoroutine(Coroutine coroutine)
        {
            _coroutine = coroutine;
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