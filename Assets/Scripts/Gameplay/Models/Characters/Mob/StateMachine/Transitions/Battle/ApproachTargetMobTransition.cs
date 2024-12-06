namespace Gameplay
{
    public class ApproachTargetMobTransition : BaseMobTransition
    {
        private readonly IMobPersistentData _persistentData;
        private readonly INoticeEnemyArea _noticeEnemyArea;
        private readonly IMobPerUpdateData _perUpdateData;
        private readonly MobConfig _config;

        public override MobState State => MobState.ApproachTarget;
        public override MobTransition Transition => MobTransition.ApproachTarget;

        public ApproachTargetMobTransition(IMobPersistentData persistentData, INoticeEnemyArea noticeEnemyArea,
            IMobPerUpdateData mobPerUpdateData, MobConfig config)
        {
            _persistentData = persistentData;
            _noticeEnemyArea = noticeEnemyArea;
            _perUpdateData = mobPerUpdateData;
            _config = config;
        }

        protected override bool Condition()
        {
            return _noticeEnemyArea.IsEnemyInsideArea;
        }

        protected override void FillConditionForStates()
        {
            base.FillConditionForStates();

            ConditionForState[MobState.RotateToTarget] = () => Condition() && _persistentData.IsRotationToTargetFinished;
            ConditionForState[MobState.AttackPause] = () => Condition() && (_noticeEnemyArea.Enemy.position - _perUpdateData.Position).magnitude > _config.AttackDistance;
        }
    }
}