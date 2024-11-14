namespace Gameplay
{
    public class MoveCharacterTransition : BaseCharacterTransition
    {
        private readonly IMoveInputData _inputData;

        public override CharacterState State => CharacterState.Move;
        public override CharacterTransition Transition => CharacterTransition.Move;

        public MoveCharacterTransition(IMoveInputData inputData)
        {
            _inputData = inputData;
        }

        protected override bool Condition()
        {
            return _inputData.InputAction.IsPressed();
        }
    }
}