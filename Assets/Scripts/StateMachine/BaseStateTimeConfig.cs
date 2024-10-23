using System;
using UnityEngine;

namespace StateMachine
{
    public abstract class BaseStateTimeConfig<TStateType, TStateToTimeDictionary> : ScriptableObject
        where TStateType : Enum
        where TStateToTimeDictionary : UnitySerializedDictionary<TStateType, float>
    {
        [SerializeField] private TStateToTimeDictionary _stateTime;

        public float GetDelay(TStateType state)
        {
            return _stateTime.ContainsKey(state) ? _stateTime[state] : 0;
        }
    }
}