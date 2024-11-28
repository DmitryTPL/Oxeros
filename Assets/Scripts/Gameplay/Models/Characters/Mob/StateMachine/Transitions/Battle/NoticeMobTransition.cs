namespace Gameplay
{
    public class NoticeMobTransition : BaseMobTransition
    {
        private readonly INoticeEnemyArea _noticeEnemyArea;

        public override MobState State => MobState.Notice;
        public override MobTransition Transition => MobTransition.Notice;

        public NoticeMobTransition(INoticeEnemyArea noticeEnemyArea)
        {
            _noticeEnemyArea = noticeEnemyArea;
        }

        protected override bool Condition()
        {
            return _noticeEnemyArea.IsEnemyInsideArea;
        }
    }
}