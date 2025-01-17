namespace Gameplay
{
    public class RespawnCharacterTransition : BaseCharacterTransition
    {
        public override CharacterState State => CharacterState.Respawn;
        public override CharacterTransition Transition => CharacterTransition.Respawn;
    }
}