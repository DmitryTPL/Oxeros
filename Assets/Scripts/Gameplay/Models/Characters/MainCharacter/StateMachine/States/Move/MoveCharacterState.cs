using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public class MoveCharacterState : BaseCharacterState
    {
        private readonly IMoveInputData _moveInputData;
        private readonly IMoveAbility _moveAbility;
        private readonly IRotateAbility _rotateAbility;
        
        public override CharacterState State => CharacterState.Move;

        public MoveCharacterState(IMoveInputData moveInputData, IMoveAbility moveAbility, IRotateAbility rotateAbility)
        {
            _moveInputData = moveInputData;
            _moveAbility = moveAbility;
            _rotateAbility = rotateAbility;
        }

        protected override async UniTask HandleControl()
        {
            await base.HandleControl();

            _moveAbility.Move(_moveInputData.Value, Config.MaxSpeed);
            _rotateAbility.Rotate(_moveInputData.Value);
        }
    }
}