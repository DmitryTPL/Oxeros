using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public class DeathCharacterState : BaseCharacterState
    {
        private readonly ICharacterDeathHandler _deathHandler;
        
        public override CharacterState State => CharacterState.Death;

        public DeathCharacterState(ICharacterDeathHandler deathHandler)
        {
            _deathHandler = deathHandler;
        }

        public override async UniTask Enter()
        {
            await base.Enter();
            
            _deathHandler.PutCharacterToDeath();
        }
    }
}