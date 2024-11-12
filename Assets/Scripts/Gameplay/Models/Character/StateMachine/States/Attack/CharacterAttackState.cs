namespace Gameplay
{
    public class AttackCharacterState : BaseCharacterState
    {
        private readonly IRotateReaction _rotateReaction;
        public override CharacterState State => CharacterState.Attack;

        protected override bool IsRotationPaused => true;

        public AttackCharacterState(IRotateReaction rotateReaction)
        {
            _rotateReaction = rotateReaction;
        }
    }
}