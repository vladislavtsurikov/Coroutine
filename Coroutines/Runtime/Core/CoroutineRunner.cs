using System;
using System.Collections;
using System.Collections.Generic;

namespace Coroutines.Runtime.Core
{
	public static class CoroutineRunner
	{
        private static readonly List<Coroutine> _coroutines = new List<Coroutine>();
        
        private static CoroutineUpdater _coroutineUpdater;
        
        static CoroutineRunner()
        {
            Type[] types = AllTypesDerivedFrom<CoroutineUpdater>.Types;

            if (types.Length > 1)
            {
                throw new Exception("There can be only one CoroutineUpdater implementation.");
            }

            _coroutineUpdater = (CoroutineUpdater)Activator.CreateInstance(types[0]);
        }
        

        public static Coroutine StartCoroutine(IEnumerator routine, object obj)
        {
            if (_coroutines.Count == 0)
            {
                _coroutineUpdater.AddUpdateFunction(OnUpdate);
            }
            
            Coroutine coroutine = new Coroutine(routine, obj);

            if (coroutine.MoveNext())
            {
                _coroutines.Add(coroutine);
            }
            
            return coroutine;
        }

        public static Coroutine StartCoroutine(IEnumerator routine)
        {
            if (_coroutines.Count == 0)
            {
                _coroutineUpdater.AddUpdateFunction(OnUpdate);
            }
            
            Coroutine coroutine = new Coroutine(routine);

            if (coroutine.MoveNext())
            {
                _coroutines.Add(coroutine);
            }

            return coroutine;
        }
        
        public static void StopCoroutine(Coroutine routine)
        {
            for (int j = _coroutines.Count - 1; j >= 0; j--)
            {
                Coroutine coroutine = _coroutines[j];
                
                if (coroutine.Finished)
                {
                    continue;
                }

                if (coroutine == routine)
                {
                    coroutine.Finished = true;
                    return;
                }
            }
        }

        public static void StopCoroutine(IEnumerator routine)
        {
            for (int j = _coroutines.Count - 1; j >= 0; j--)
            {
                Coroutine coroutine = _coroutines[j];
                
                if (coroutine.Finished)
                {
                    continue;
                }

                if (coroutine.Routine.MethodName() == routine.MethodName())
                {
                    coroutine.Finished = true;
                }
            }
        }
        
        public static void StopCoroutine(IEnumerator routine, object reference)
        {
            for (int j = _coroutines.Count - 1; j >= 0; j--)
            {
                Coroutine coroutine = _coroutines[j];

                if (coroutine.Finished || coroutine.Owner == null)
                {
                    continue;
                }

                if (coroutine.Owner.Target != null && coroutine.Owner.Target == reference)
                {
                    if (coroutine.Routine.MethodName() == routine.MethodName())
                    {
                        coroutine.Finished = true;
                    }
                }
            }
        }

        public static void StopCoroutines(object reference)
        {
            for (int j = _coroutines.Count - 1; j >= 0; j--)
            {
                Coroutine coroutine = _coroutines[j];
                
                if (coroutine.Finished || coroutine.Owner == null)
                {
                    continue;
                }
                
                if (coroutine.Owner.Target != null && coroutine.Owner.Target == reference)
                {
                    coroutine.Finished = true;
                }
            }
        }
        
        public static void StopAllCoroutines()
        {
            _coroutines.Clear();
        }

        private static void OnUpdate()
        {
            if (_coroutines.Count == 0)
            {
                _coroutineUpdater.RemoveUpdateFunction(OnUpdate);
                return;
            }

            for (int j = _coroutines.Count - 1; j >= 0; j--)
            {
                Coroutine coroutine = _coroutines[j];

                if (coroutine.Finished || !coroutine.MoveNext())
                {
                    _coroutines.RemoveAt(j);
                    coroutine.CurrentYield = null;
                    coroutine.Finished = true;
                }
            }
        }
	}
}