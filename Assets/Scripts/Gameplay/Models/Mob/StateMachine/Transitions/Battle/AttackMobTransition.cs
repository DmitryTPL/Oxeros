namespace Gameplay
{
    public class AttackMobTransition : BaseMobTransition
    {
        public override MobState State => MobState.Attack;
        public override MobTransition Transition => MobTransition.Attack;
    }
}