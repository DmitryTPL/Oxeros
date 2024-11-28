namespace Gameplay
{
    public class RoamMobTransition : BaseMobTransition
    {
        private readonly IMobPersistentData _persistentData;

        public override MobState State => MobState.Roam;
        public override MobTransition Transition => MobTransition.Roam;

        public RoamMobTransition(IMobPersistentData persistentData)
        {
            _persistentData = persistentData;
        }

        protected override void FillConditionForStates()
        {
            base.FillConditionForStates();

            ConditionForState[MobState.RoamRotation] = () => _persistentData.IsRoamRotationFinished;
        }
    }
}