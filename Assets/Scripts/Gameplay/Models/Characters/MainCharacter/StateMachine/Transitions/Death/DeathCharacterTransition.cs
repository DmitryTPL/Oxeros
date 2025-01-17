namespace Gameplay
{
    public class DeathCharacterTransition : BaseCharacterTransition
    {
        private readonly IHealthHandler _healthHandler;

        public override CharacterState State => CharacterState.Death;
        public override CharacterTransition Transition => CharacterTransition.Death;

        public DeathCharacterTransition(IHealthHandler healthHandler)
        {
            _healthHandler = healthHandler;
        }

        protected override bool Condition()
        {
            return _healthHandler.Health.Value <= float.Epsilon;
        }
    }
}