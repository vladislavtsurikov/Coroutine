using System.Reflection;
using UnityEngine;

namespace Coroutines.Runtime.UnityIntergration.Updater
{
    public class DontDestroyMonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                
                MonoBehaviourNameAttribute monoBehaviourNameAttribute = (MonoBehaviourNameAttribute)typeof(T).GetCustomAttribute(typeof(MonoBehaviourNameAttribute));
                        
                GameObject obj = new GameObject { name = monoBehaviourNameAttribute.Name };
                
                DontDestroyOnLoad(obj);
                        
                _instance = obj.AddComponent<T>();

                return _instance;
            }
        }

        public static T GetInstance()
        {
            return _instance;
        }
        
        public static void DestroyGameObject()
        {
            if (_instance != null)
            {
                DestroyImmediate(_instance.gameObject);
            }
        }
    }
}