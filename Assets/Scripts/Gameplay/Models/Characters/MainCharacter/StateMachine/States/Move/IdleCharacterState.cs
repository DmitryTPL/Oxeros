using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public class IdleCharacterState : BaseCharacterState
    {
        private readonly IMoveAbility _moveAbility;
        private readonly IRotateAbility _rotateAbility;
        private Vector3 _lastDirection;

        public override CharacterState State => CharacterState.Idle;


        public IdleCharacterState(IMoveAbility moveAbility, IRotateAbility rotateAbility)
        {
            _moveAbility = moveAbility;
            _rotateAbility = rotateAbility;
        }

        public override async UniTask Enter()
        {
            await base.Enter();

            _moveAbility.StopMovement();
            _rotateAbility.StopRotation();
        }
    }
}