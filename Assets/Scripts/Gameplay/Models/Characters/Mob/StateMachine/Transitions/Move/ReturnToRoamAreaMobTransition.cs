namespace Gameplay
{
    public class ReturnToRoamAreaMobTransition : BaseMobTransition
    {
        private readonly INoticeEnemyArea _noticeEnemyArea;
        
        public override MobState State => MobState.ReturnToRoamArea;
        public override MobTransition Transition => MobTransition.ReturnToRoamArea;

        public ReturnToRoamAreaMobTransition(INoticeEnemyArea noticeEnemyArea)
        {
            _noticeEnemyArea = noticeEnemyArea;
        }

        protected override bool Condition()
        {
            return !_noticeEnemyArea.IsEnemyInsideArea;
        }
    }
}