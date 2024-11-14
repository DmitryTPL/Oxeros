namespace Gameplay
{
    public class IdleCharacterTransition : BaseCharacterTransition
    {
        private readonly IMoveInputData _inputData;

        public override CharacterState State => CharacterState.Idle;
        public override CharacterTransition Transition => CharacterTransition.Idle;

        public IdleCharacterTransition(IMoveInputData inputData)
        {
            _inputData = inputData;
        }

        protected override bool Condition()
        {
            return !_inputData.InputAction.IsPressed();
        }
    }
}