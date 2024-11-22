namespace Gameplay
{
    public class RoamMobTransition : BaseMobTransition
    {
        public override MobState State => MobState.Roam;
        public override MobTransition Transition => MobTransition.Roam;
    }
}