using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public class AttackCharacterState : BaseCharacterState
    {
        private readonly IMoveInputData _moveInputData;
        
        public override CharacterState State => CharacterState.Attack;

        public AttackCharacterState(IMoveInputData moveInputData)
        {
            _moveInputData = moveInputData;
        }

        public override async UniTask Enter()
        {
            await base.Enter();
            
            PersistentData.IsDefending = false;
        }

        protected override async UniTask HandleControl()
        {
            await base.HandleControl();
            
            ApplyMove(_moveInputData.Value * Config.MaxSpeed);
        }
    }
}