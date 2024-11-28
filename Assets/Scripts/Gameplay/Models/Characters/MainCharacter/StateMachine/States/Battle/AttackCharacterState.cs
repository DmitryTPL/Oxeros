﻿using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public class AttackCharacterState : BaseCharacterState
    {
        private readonly IMoveInputData _moveInputData;
        private readonly IMoveAbility _moveAbility;
        private readonly IRotateAbility _rotateAbility;
        private readonly ICharacterPersistentData _persistentData;
        public override CharacterState State => CharacterState.Attack;

        public AttackCharacterState(IMoveInputData moveInputData, IMoveAbility moveAbility, IRotateAbility rotateAbility, ICharacterPersistentData persistentData)
        {
            _moveAbility = moveAbility;
            _rotateAbility = rotateAbility;
            _persistentData = persistentData;
            _moveInputData = moveInputData;
        }

        public override async UniTask Enter()
        {
            await base.Enter();

            _persistentData.IsDefending = false;
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
    }
}