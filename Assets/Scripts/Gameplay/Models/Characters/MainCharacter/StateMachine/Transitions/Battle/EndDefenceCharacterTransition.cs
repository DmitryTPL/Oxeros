namespace Gameplay
{
    public class EndDefenceCharacterTransition : BaseCharacterTransition
    {
        private readonly IDefenceInputData _defenceInputData;
        private readonly ICharacterPersistentData _characterPersistentData;

        public override CharacterState State => CharacterState.EndDefence;
        public override CharacterTransition Transition => CharacterTransition.EndDefence;
        
        public EndDefenceCharacterTransition(IDefenceInputData defenceInputData, ICharacterPersistentData characterPersistentData)
        {
            _defenceInputData = defenceInputData;
            _characterPersistentData = characterPersistentData;
        }

        protected override bool Condition()
        {
            return _characterPersistentData.IsDefending && !_defenceInputData.InputAction.IsPressed();
        }
    }
}