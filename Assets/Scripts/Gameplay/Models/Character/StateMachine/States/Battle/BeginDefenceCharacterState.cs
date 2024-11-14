using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public class BeginDefenceCharacterState : BaseCharacterState
    {
        private readonly IMoveInputData _moveInputData;

        public override CharacterState State => CharacterState.BeginDefence;

        public BeginDefenceCharacterState(IMoveInputData moveInputData)
        {
            _moveInputData = moveInputData;
        }

        public override async UniTask Enter()
        {
            await base.Enter();
            
            PersistentData.IsDefending = true;
        }

        protected override async UniTask HandleControl()
        {
            await base.HandleControl();

            ApplyMove(_moveInputData.Value * Config.MaxSpeed);
        }
    }
}