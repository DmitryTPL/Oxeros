namespace Gameplay
{
    public class RotateToTargetMobTransition : BaseMobTransition
    {
        public override MobState State => MobState.RotateToTarget;
        public override MobTransition Transition => MobTransition.RotateToTarget;
    }
}