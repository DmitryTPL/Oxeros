namespace Gameplay
{
    public class BeginDefenceCharacterTransition : BaseCharacterTransition
    {
        private readonly IDefenceInputData _defenceInputData;
        private readonly IDefenceHandler _defenceHandler;

        public override CharacterState State => CharacterState.BeginDefence;
        public override CharacterTransition Transition => CharacterTransition.BeginDefence;

        public BeginDefenceCharacterTransition(IDefenceInputData defenceInputData, IDefenceHandler defenceHandler)
        {
            _defenceInputData = defenceInputData;
            _defenceHandler = defenceHandler;
        }

        protected override bool Condition()
        {
            return !_defenceHandler.IsDefending.Value && _defenceInputData.InputAction.IsPressed();
        }
    }
}