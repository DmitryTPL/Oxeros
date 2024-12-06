using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public class AttackCharacterState : BaseCharacterState
    {
        private readonly IMoveInputData _moveInputData;
        private readonly IMoveAbility _moveAbility;
        private readonly IRotateAbility _rotateAbility;
        private readonly ICharacterPersistentData _persistentData;
        private readonly IAttackAbility _attackAbility;

        public override CharacterState State => CharacterState.Attack;

        public AttackCharacterState(IMoveInputData moveInputData, IMoveAbility moveAbility, IRotateAbility rotateAbility, ICharacterPersistentData persistentData,
            IAttackAbility attackAbility)
        {
            _moveAbility = moveAbility;
            _rotateAbility = rotateAbility;
            _persistentData = persistentData;
            _attackAbility = attackAbility;
            _moveInputData = moveInputData;
        }

        public override async UniTask Enter()
        {
            await base.Enter();

            _persistentData.IsDefending = false;

            _attackAbility.BeginAttack();
        }

        protected override async UniTask HandleControl()
        {
            await base.HandleControl();

            if (_moveInputData.Value != Vector3.zero)
            {
                _moveAbility.Move(_moveInputData.Value, Config.MaxSpeed);
                _rotateAbility.Rotate(_moveInputData.Value);
            }
            else
            {
                _rotateAbility.StopRotation();
            }
        }

        public override async UniTask Exit()
        {
            await base.Exit();

            _attackAbility.EndAttack();
        }
    }
}