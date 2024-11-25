using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public class EndDefenceCharacterState : BaseCharacterState
    {
        private readonly ICharacterPersistentData _persistentData;
        public override CharacterState State => CharacterState.EndDefence;

        public EndDefenceCharacterState(ICharacterPersistentData persistentData)
        {
            _persistentData = persistentData;
        }

        public override async UniTask Exit()
        {
            await base.Exit();
            
            _persistentData.IsDefending = false;
        }
    }
}