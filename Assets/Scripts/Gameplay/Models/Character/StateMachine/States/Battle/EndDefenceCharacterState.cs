using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public class EndDefenceCharacterState : BaseCharacterState
    {
        public override CharacterState State => CharacterState.EndDefence;

        public override async UniTask Exit()
        {
            await base.Exit();
            
            PersistentData.IsDefending = false;
        }
    }
}