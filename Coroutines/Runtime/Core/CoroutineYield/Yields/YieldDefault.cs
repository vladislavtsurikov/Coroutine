namespace Coroutines.Runtime.Core
{
    internal class YieldDefault : ICoroutineYield
    {
        private bool _waitNextFrame = true;

        public bool IsDone()
        {
            if (_waitNextFrame)
            {
                _waitNextFrame = false;
                return false;
            }
			
            return true;
        }
    }
}