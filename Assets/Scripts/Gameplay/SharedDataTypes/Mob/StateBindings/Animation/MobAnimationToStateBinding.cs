using System;
using StateBindings;

namespace Gameplay
{
    [Serializable]
    public class MobAnimationToStateBinding : BaseDataToStateBinding<AnimationData<MobState, MobAnimationLayer>, MobState>
    {
    }
}