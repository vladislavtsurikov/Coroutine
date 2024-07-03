using System;
using UnityEditor;
using UnityEngine;

namespace Coroutines.Runtime.UnityIntergration.Updater
{
    public static class EditorAndRuntimeUpdater
    {
        public static event Action UpdateEvent;

        static EditorAndRuntimeUpdater()
        {
            if (Application.isPlaying)
            {
                UniversalToolkitRuntimeUpdate universalToolkitRuntimeUpdate = UniversalToolkitRuntimeUpdate.Instance;
            }
            else
            {
#if UNITY_EDITOR
                EditorApplication.update += EditorUpdate;
#endif
            }
        }

#if UNITY_EDITOR
        private static void EditorUpdate()
        {
            UpdateEvent?.Invoke();
        }
#endif
        
        [MonoBehaviourName("Runtime Updater")]
        public class UniversalToolkitRuntimeUpdate : DontDestroyMonoBehaviourSingleton<UniversalToolkitRuntimeUpdate>
        {
            private void Update()
            {
                UpdateEvent?.Invoke();
            }
        }
    }
}