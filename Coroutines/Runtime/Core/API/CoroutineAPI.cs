using System.Collections;
using Coroutines.Runtime.Core;

namespace Coroutines
{
    public static class CoroutineAPI
    {
        public static Coroutine StartCoroutine(IEnumerator routine, object obj = null)
        {
            return CoroutineRunner.StartCoroutine(routine, obj);
        }

        public static void StopCoroutine(Coroutine routine)
        {
            CoroutineRunner.StopCoroutine(routine);
        }

        public static void StopCoroutine(IEnumerator routine)
        {
            CoroutineRunner.StopCoroutine(routine);
        }

        public static void StopCoroutine(IEnumerator routine, object reference)
        {
            CoroutineRunner.StopCoroutine(routine, reference);
        }

        public static void StopCoroutines(object reference)
        {
            CoroutineRunner.StopCoroutines(reference);
        }

        public static void StopAllCoroutines()
        {
            CoroutineRunner.StopAllCoroutines();
        }
    }
}