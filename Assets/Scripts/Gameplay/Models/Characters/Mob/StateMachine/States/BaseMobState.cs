using StateMachine;
using Zenject;

namespace Gameplay
{
    public abstract class BaseMobState : BaseStateWithTransitions<MobState, MobTransition, IMobTransition, IMobTransitionsHolder, IMobStateTimingHandler, MobStateTimeConfig,
        MobStateToTimeDictionary>, IMobState
    {
        protected MobConfig Config { get; private set; }

        [Inject]
        public void AddDependencies(MobConfig config)
        {
            Config = config;
        }
    }
}