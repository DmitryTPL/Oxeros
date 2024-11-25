namespace Gameplay
{
    public class ReturnToRoamAreaMobTransition : BaseMobTransition
    {
        public override MobState State => MobState.ReturnToRoamArea;
        public override MobTransition Transition => MobTransition.ReturnToRoamArea;
    }
}