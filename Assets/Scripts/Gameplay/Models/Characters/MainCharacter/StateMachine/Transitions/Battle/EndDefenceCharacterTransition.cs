namespace Gameplay
{
    public class EndDefenceCharacterTransition : BaseCharacterTransition
    {
        private readonly IDefenceInputData _defenceInputData;
        private readonly IDefenceHandler _defenceHandler;

        public override CharacterState State => CharacterState.EndDefence;
        public override CharacterTransition Transition => CharacterTransition.EndDefence;

        public EndDefenceCharacterTransition(IDefenceInputData defenceInputData, IDefenceHandler defenceHandler)
        {
            _defenceInputData = defenceInputData;
            _defenceHandler = defenceHandler;
            _defenceHandler = defenceHandler;
        }

        protected override bool Condition()
        {
            return _defenceHandler.IsDefending.Value && !_defenceInputData.InputAction.IsPressed();
        }
    }
}