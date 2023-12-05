using System;
using System.Collections;
using UnityEngine;

namespace Services
{
    public class CoroutineService : MonoBehaviour, ICoroutineService
    {
        #region --- Public Methods ---
        
        public Coroutine CoroutineStart(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }

        public void CoroutineStop(Coroutine routine)
        {
            StopCoroutine(routine);
        }
    
        public Coroutine StartAfterDelay(IEnumerator routine, float delay)
        {
            return StartCoroutine(StartAfterDelayRoutine(routine, delay));
        }
    
        public Coroutine ExecuteAfterDelay(Action action, float delay)
        {
            return StartCoroutine(ExecuteAfterDelayRoutine(action, delay));
        }
        
        #endregion
        
        
        #region --- Private Methods ---

        private IEnumerator StartAfterDelayRoutine(IEnumerator routine, float delay)
        {
            yield return new WaitForSeconds(delay);
            yield return routine;
        }
    
        private IEnumerator ExecuteAfterDelayRoutine(Action action, float delay)
        {
            yield return new WaitForSeconds(delay);

            action?.Invoke();
        }
        
        #endregion
    }
}