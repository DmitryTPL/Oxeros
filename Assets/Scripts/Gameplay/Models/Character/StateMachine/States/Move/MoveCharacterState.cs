﻿using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public class MoveCharacterState : BaseCharacterState
    {
        private readonly IMoveInputData _moveInputData;

        public override CharacterState State => CharacterState.Move;

        public MoveCharacterState(IMoveInputData moveInputData)
        {
            _moveInputData = moveInputData;
        }

        protected override async UniTask HandleControl()
        {
            await base.HandleControl();

            ApplyMove(_moveInputData.Value * Config.MaxSpeed);
        }
    }
}