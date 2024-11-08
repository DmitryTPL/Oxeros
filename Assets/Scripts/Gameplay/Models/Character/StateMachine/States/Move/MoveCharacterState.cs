using System.Numerics;
using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public class MoveCharacterState : BaseCharacterState
    {
        private readonly IMoveInputData _moveInputData;
        private readonly IMoveStateReaction _moveStateReaction;

        public override CharacterState State => CharacterState.Move;

        public MoveCharacterState(IMoveInputData moveInputData, IMoveStateReaction moveStateReaction)
        {
            _moveInputData = moveInputData;
            _moveStateReaction = moveStateReaction;
        }

        protected override async UniTask HandleControl()
        {
            await base.HandleControl();

            _moveStateReaction.Acceleration.Value = GetMoveDelta(_moveInputData.Value * Config.MaxSpeed);
        }
    }
}