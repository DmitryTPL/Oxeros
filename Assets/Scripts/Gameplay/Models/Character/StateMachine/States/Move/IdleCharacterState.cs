using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public class IdleCharacterState : BaseCharacterState
    {
        private readonly IMoveReaction _moveReaction;
        private Vector3 _lastDirection;

        public override CharacterState State => CharacterState.Idle;

        protected override bool IsRotationPaused => true;

        public IdleCharacterState(IMoveReaction moveReaction)
        {
            _moveReaction = moveReaction;
        }

        public override async UniTask Enter()
        {
            await base.Enter();

            _moveReaction.Acceleration.Value = Vector3.zero;
        }
    }
}