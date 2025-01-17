using Cysharp.Threading.Tasks;
using StateMachine;

namespace Gameplay
{
    public class RespawnCharacterState : BaseCharacterState
    {
        private readonly IHealthHandler _healthHandler;
        private readonly IRespawnHandler _respawnHandler;
        private readonly IRespawnAbility _respawnAbility;

        public override CharacterState State => CharacterState.Respawn;

        public RespawnCharacterState(IHealthHandler healthHandler, IRespawnHandler respawnHandler, IRespawnAbility respawnAbility)
        {
            _healthHandler = healthHandler;
            _respawnHandler = respawnHandler;
            _respawnAbility = respawnAbility;
        }

        public override async UniTask Enter()
        {
            await base.Enter();

            _healthHandler.Restore(_healthHandler.MaxHealth.Value);

            _respawnAbility.RespawnOnPosition(_respawnHandler.LastActiveRespawnPosition);
        }
    }
}