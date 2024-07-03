using System;

namespace Coroutines.Runtime.Core
{
    public abstract class CoroutineUpdater
    {
        public abstract void AddUpdateFunction(Action function);
        public abstract void RemoveUpdateFunction(Action function);
    }
}