namespace Gameplay
{
    public class AttackMobTransition : BaseMobTransition
    {
        private readonly IMobPersistentData _persistentData;

        public override MobState State => MobState.Attack;
        public override MobTransition Transition => MobTransition.Attack;

        public AttackMobTransition(IMobPersistentData persistentData)
        {
            _persistentData = persistentData;
        }

        protected override bool Condition()
        {
            return _persistentData.IsTargetApproached;
        }
    }
}