using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public class BeginDefenceCharacterState : BaseCharacterState
    {
        private readonly IDefenceHandler _defenceHandler;

        public override CharacterState State => CharacterState.BeginDefence;

        public BeginDefenceCharacterState(IDefenceHandler defenceHandler)
        {
            _defenceHandler = defenceHandler;
        }

        public override async UniTask Enter()
        {
            await base.Enter();

            _defenceHandler.SetDefendingState(true);
        }
    }
}