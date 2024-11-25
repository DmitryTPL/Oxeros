using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public class BeginDefenceCharacterState : BaseCharacterState
    {
        private readonly ICharacterPersistentData _persistentData;

        public override CharacterState State => CharacterState.BeginDefence;

        public BeginDefenceCharacterState(ICharacterPersistentData persistentData)
        {
            _persistentData = persistentData;
        }

        public override async UniTask Enter()
        {
            await base.Enter();

            _persistentData.IsDefending = true;
        }
    }
}