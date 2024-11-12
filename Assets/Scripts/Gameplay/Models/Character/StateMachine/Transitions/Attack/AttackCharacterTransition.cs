namespace Gameplay
{
    public class AttackCharacterTransition : BaseCharacterTransition
    {
        private readonly IAttackInputData _attackInputData;

        public override CharacterState MoveToState => CharacterState.Attack;
        public override CharacterTransition Transition => CharacterTransition.Attack;

        public AttackCharacterTransition(IAttackInputData attackInputData)
        {
            _attackInputData = attackInputData;
        }

        protected override bool Condition()
        {
            return _attackInputData.InputAction.IsPressed();
        }
    }
}