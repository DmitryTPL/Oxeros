namespace Gameplay
{
    public class RoamRotationMobTransition : BaseMobTransition
    {
        private readonly IMobPersistentData _persistentData;
        
        public override MobState State => MobState.RoamRotation;
        public override MobTransition Transition => MobTransition.RoamRotation;

        public RoamRotationMobTransition(IMobPersistentData persistentData)
        {
            _persistentData = persistentData;
        }

        protected override void FillConditionForStates()
        {
            base.FillConditionForStates();

            ConditionForState[MobState.Roam] = () => _persistentData.RoamMoveOnPathFinished;
        }
    }
}