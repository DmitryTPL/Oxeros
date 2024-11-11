using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public class MoveCharacterState : BaseCharacterState
    {
        private readonly IMoveInputData _moveInputData;
        private readonly IMoveReaction _moveReaction;

        public override CharacterState State => CharacterState.Move;
        protected override Vector3 MoveDirection => _moveInputData.Value.normalized;

        public MoveCharacterState(IMoveInputData moveInputData, IMoveReaction moveReaction)
        {
            _moveInputData = moveInputData;
            _moveReaction = moveReaction;
        }

        protected override async UniTask HandleControl()
        {
            await base.HandleControl();

            _moveReaction.Acceleration.Value = GetMoveDelta(_moveInputData.Value * Config.MaxSpeed);
        }
    }
}