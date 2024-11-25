namespace Gameplay
{
    public class ApproachMobTransition : BaseMobTransition
    {
        public override MobState State => MobState.Approach;
        public override MobTransition Transition => MobTransition.Approach;
    }
}