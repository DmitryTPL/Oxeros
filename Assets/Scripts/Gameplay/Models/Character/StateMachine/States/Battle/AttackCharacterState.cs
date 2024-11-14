using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public class AttackCharacterState : BaseCharacterState
    {
        public override CharacterState State => CharacterState.Attack;

        public override async UniTask Enter()
        {
            await base.Enter();
            
            PersistentData.IsDefending = false;
        }

        protected override async UniTask HandleControl()
        {
            await base.HandleControl();
            
            ApplyMove(Config.MaxSpeed);
        }
    }
}