using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public class IdleCharacterState : BaseCharacterState
    {
        private readonly IMoveReaction _moveReaction;
        private readonly IRotateReaction _rotateReaction;
        private Vector3 _lastDirection;

        public override CharacterState State => CharacterState.Idle;

        protected override bool IsRotationPaused => true;

        public IdleCharacterState(IMoveReaction moveReaction, IRotateReaction rotateReaction)
        {
            _moveReaction = moveReaction;
            _rotateReaction = rotateReaction;
        }

        public override async UniTask Enter()
        {
            await base.Enter();

            _moveReaction.Acceleration.Value = Vector3.zero;
            _rotateReaction.Stop.Value = true;
            _rotateReaction.Rotation.Value = Vector3.zero;
        }
    }
}