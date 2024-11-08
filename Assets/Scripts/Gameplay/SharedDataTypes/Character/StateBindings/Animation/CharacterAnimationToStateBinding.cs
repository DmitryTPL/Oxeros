using System;
using StateBindings;

namespace Gameplay
{
    [Serializable]
    public class CharacterAnimationToStateBinding : BaseDataToStateBinding<AnimationData<CharacterState, CharacterAnimationLayer>, CharacterState>
    {
    }
}