using System;
using System.Collections;

namespace Coroutines.Runtime.Core
{
	public class Coroutine
	{
		internal ICoroutineYield CurrentYield;
		
		internal readonly IEnumerator Routine;
		internal readonly WeakReference Owner;
		
		public bool Finished;

		internal Coroutine(IEnumerator routine)
        {
	        Owner = null;
            Routine = routine;
            Routine.MoveNext();
            SetCurrentYield();
        }

        internal Coroutine(IEnumerator routine, object owner)
        {
	        Owner = new WeakReference(owner);
	        Routine = routine;
	        Routine.MoveNext();
	        SetCurrentYield();
        }

        private void SetCurrentYield()
        {
	        CurrentYield = CoroutineYield.Get(Routine);
        }

        internal bool MoveNext()
        {
	        if (CurrentYield == null)
	        {
		        return false;
	        }

	        if (CurrentYield.IsDone())
	        {
		        if (Routine.MoveNext())
		        {
			        SetCurrentYield();

			        if (MoveNext())
			        {
				        return true;
			        }
			        else
			        {
				        return false;
			        }
		        }
		        else
		        {
			        return false;
		        }
	        }
	        else
	        {
		        return true;
	        }
        }
	}
}