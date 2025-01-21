using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public class EndDefenceCharacterState : BaseCharacterState
    {
        private readonly IDefenceHandler _defenceHandler;
        public override CharacterState State => CharacterState.EndDefence;

        public EndDefenceCharacterState(IDefenceHandler defenceHandler)
        {
            _defenceHandler = defenceHandler;
        }

        public override async UniTask Exit()
        {
            await base.Exit();

            _defenceHandler.SetDefendingState(false);
        }
    }
}