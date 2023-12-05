using System;
using System.Collections;
using UnityEngine;

namespace Services
{
    public interface ICoroutineService
    {
        #region --- Methods ---
        
        Coroutine CoroutineStart(IEnumerator routine);
        Coroutine StartAfterDelay(IEnumerator routine, float delay);
        Coroutine ExecuteAfterDelay(Action action, float delay);
        void CoroutineStop(Coroutine routine);
        
        #endregion
    }
}