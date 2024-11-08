using System;
using StateMachine;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public class CharacterTransitionActivity : BaseTransitionActivity<CharacterTransition>
    {
#pragma warning disable CS0414
        [Serializable]
        public class Move : BaseTransitionActivityDescription
        {
            [SerializeField] [Transition((int)CharacterTransition.Idle)] private bool _idle = true;
            [SerializeField] [Transition((int)CharacterTransition.Move)] private bool _move = true;
        }

        [SerializeField] private Move _move;

        protected override CharacterTransition ConvertFromInt(int value)
        {
            return (CharacterTransition)value;
        }
#pragma warning restore CS0414
    }
}