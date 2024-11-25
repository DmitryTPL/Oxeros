namespace Gameplay
{
    public class BeginDefenceCharacterTransition : BaseCharacterTransition
    {
        private readonly IDefenceInputData _defenceInputData;
        private readonly ICharacterPersistentData _persistentData;

        public override CharacterState State => CharacterState.BeginDefence;
        public override CharacterTransition Transition => CharacterTransition.BeginDefence;

        public BeginDefenceCharacterTransition(IDefenceInputData defenceInputData, ICharacterPersistentData persistentData)
        {
            _defenceInputData = defenceInputData;
            _persistentData = persistentData;
        }

        protected override bool Condition()
        {
            return !_persistentData.IsDefending && _defenceInputData.InputAction.IsPressed();
        }
    }
}