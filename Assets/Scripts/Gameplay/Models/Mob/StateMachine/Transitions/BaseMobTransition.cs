using StateMachine;
using Zenject;

namespace Gameplay
{
    public abstract class BaseMobTransition : BaseTransition<MobState, MobTransition>, IMobTransition
    {
        [Inject]
        public void AddDependencies(MobTransitionsConfig config, IMobStateTimingHandler stateDelayHandler)
        {
            Initialize(config, stateDelayHandler);
        }
    }
}