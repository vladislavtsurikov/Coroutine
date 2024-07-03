using Coroutines.Runtime.Core;
using UnityEngine;

namespace Coroutines.Runtime.UnityIntergration
{
    internal class YieldWaitForSeconds : ICoroutineYield
    {
        private float _timeToFinish;

        public YieldWaitForSeconds(float seconds)
        {
            _timeToFinish = Time.time + seconds;
        }

        public bool IsDone()
        {
            return _timeToFinish <= Time.time;
        }
    }
}