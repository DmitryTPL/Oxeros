using StateMachine;
using Zenject;

namespace Gameplay
{
    public abstract class BaseMobState : BaseStateWithTransitions<MobState, MobTransition, IMobTransition, IMobTransitionsHolder, IMobStateTimingHandler, MobStateTimeConfig, MobStateToTimeDictionary>, IMobState
    {
        protected MobConfig Config { get; private set; }
        protected IPersistentData PersistentData { get; private set; }
        protected IPerUpdateData PerUpdateData { get; private set; }
        
        [Inject]
        public void AddDependencies(MobConfig config, IMobPersistentData persistentData, IMobPerUpdateData perUpdateData)
        {
            Config = config;
            PersistentData = persistentData;
            PerUpdateData = perUpdateData;
        }
    }
}