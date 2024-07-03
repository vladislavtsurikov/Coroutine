#if UNITY_EDITOR
using Coroutines.Runtime;
using Coroutines.Runtime.Core;
using UnityEditor;

namespace Coroutines.Editor.UnityIntergration
{
	public static class EditorCoroutineExtensions
	{
		public static void StopCoroutine(this EditorWindow thisRef, Coroutine routine)
		{
			CoroutineRunner.StopCoroutine(routine);
		}

		public static void StopAllCoroutines(this EditorWindow thisRef)
		{
			CoroutineRunner.StopCoroutines(thisRef);
		}
	}
}
#endif