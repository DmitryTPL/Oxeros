namespace Gameplay
{
    public class WaitForTargetMobTransition : BaseMobTransition
    {
        private readonly INoticeEnemyArea _noticeEnemyArea;
        
        public override MobState State => MobState.WaitForTarget;
        public override MobTransition Transition => MobTransition.WaitForTarget;

        public WaitForTargetMobTransition(INoticeEnemyArea noticeEnemyArea)
        {
            _noticeEnemyArea = noticeEnemyArea;
        }

        protected override bool Condition()
        {
            return !_noticeEnemyArea.IsEnemyInsideArea;
        }
    }
}