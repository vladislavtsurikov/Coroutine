using System;
using Coroutines.Runtime.Core;

namespace Coroutines.Runtime.UnityIntergration.Updater
{
    public class UnityCoroutineUpdater : CoroutineUpdater
    {
        public override void AddUpdateFunction(Action function)
        {
            EditorAndRuntimeUpdater.UpdateEvent += function;
        }

        public override void RemoveUpdateFunction(Action function)
        {
            EditorAndRuntimeUpdater.UpdateEvent -= function;
        }
    }
}