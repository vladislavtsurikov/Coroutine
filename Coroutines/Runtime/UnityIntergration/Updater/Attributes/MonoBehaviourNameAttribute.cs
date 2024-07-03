using System;

namespace Coroutines.Runtime.UnityIntergration.Updater
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MonoBehaviourNameAttribute : Attribute
    {
        public readonly string Name;

        public MonoBehaviourNameAttribute(string name)
        {
            Name = name;
        }
    }
}