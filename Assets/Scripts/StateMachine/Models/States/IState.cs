﻿using System;
using Cysharp.Threading.Tasks;

namespace StateMachine
{
    public interface IState<TStateType>
        where TStateType : Enum
    {
        TStateType State { get; }
        UniTask Enter();
        UniTask<TStateType> Execute();
        UniTask Exit();
    }
}