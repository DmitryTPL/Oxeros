using System;
using UnityEngine;

namespace StateBindings
{
    [Serializable]
    public struct AnimationTransitionData<TStateType>
        where TStateType : Enum
    {
        [SerializeField] private TStateType _to;
        [SerializeField] private float _durationPercent;

        public TStateType To => _to;
        public float DurationPercent => _durationPercent;
    }
}