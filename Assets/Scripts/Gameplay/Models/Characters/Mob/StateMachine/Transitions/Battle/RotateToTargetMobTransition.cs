namespace Gameplay
{
    public class RotateToTargetMobTransition : BaseMobTransition
    {
        private readonly INoticeEnemyArea _noticeEnemyArea;
        private readonly IMobPerUpdateData _perUpdateData;
        private readonly MobConfig _config;

        public override MobState State => MobState.RotateToTarget;
        public override MobTransition Transition => MobTransition.RotateToTarget;

        public RotateToTargetMobTransition(INoticeEnemyArea noticeEnemyArea, IMobPerUpdateData perUpdateData, MobConfig config)
        {
            _noticeEnemyArea = noticeEnemyArea;
            _perUpdateData = perUpdateData;
            _config = config;
        }

        protected override bool Condition()
        {
            return _noticeEnemyArea.IsEnemyInsideArea;
        }
    }
}