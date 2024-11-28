using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public class AttackMobState : BaseMobState
    {
        private readonly IMoveAbility _moveAbility;
        private readonly IRotateAbility _rotateAbility;
        private readonly INoticeEnemyArea _noticeEnemyArea;
        private readonly IMobPerUpdateData _perUpdateData;

        public override MobState State => MobState.Attack;

        public AttackMobState(IMoveAbility moveAbility, IRotateAbility rotateAbility, INoticeEnemyArea noticeEnemyArea,
            IMobPerUpdateData perUpdateData)
        {
            _moveAbility = moveAbility;
            _rotateAbility = rotateAbility;
            _noticeEnemyArea = noticeEnemyArea;
            _perUpdateData = perUpdateData;
        }

        public override async UniTask Enter()
        {
            await base.Enter();

            _moveAbility.StopMovement();
            _rotateAbility.StopRotation();
        }

        protected override async UniTask HandleControl()
        {
            await base.HandleControl();

            var distance = Vector3.ProjectOnPlane(_noticeEnemyArea.Enemy.position - _perUpdateData.Position, Vector3.up);

            _rotateAbility.ForceRotate(distance.normalized);
        }
    }
}