using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public class RoamMobState : BaseMobState
    {
        private readonly IMoveAbility _moveAbility;
        private readonly IMobPerUpdateData _perUpdateData;
        private readonly IMobPersistentData _persistentData;

        public override MobState State => MobState.Roam;

        public RoamMobState(IMoveAbility moveAbility, IMobPerUpdateData perUpdateData, IMobPersistentData persistentData)
        {
            _moveAbility = moveAbility;
            _perUpdateData = perUpdateData;
            _persistentData = persistentData;
        }

        protected override async UniTask HandleControl()
        {
            await base.HandleControl();

            if (_perUpdateData.Position.IsDestinationReached(_persistentData.RoamPathDestination, _persistentData.RoamPathStart, 0.1f, true))
            {
                _persistentData.RoamMoveOnPathFinished = true;
                return;
            }

            _moveAbility.Move(_persistentData.RoamPathDirection, Config.RoamingMaxSpeed);

            Debug.DrawLine(_perUpdateData.Position, _persistentData.RoamPathDestination, Color.red);
        }

        public override async UniTask Exit()
        {
            await base.Enter();

            _persistentData.RoamMoveOnPathFinished = false;
        }
    }
}