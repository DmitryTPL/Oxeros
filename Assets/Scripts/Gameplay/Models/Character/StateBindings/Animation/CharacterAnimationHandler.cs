using StateBindings;

namespace Gameplay
{
    public interface ICharacterAnimationHandler : IAnimationHandler<CharacterState, CharacterAnimationLayer>
    {
    }

    public class CharacterAnimationHandler : AnimationHandler<CharacterState, CharacterAnimationLayer>, ICharacterAnimationHandler
    {
    }
}