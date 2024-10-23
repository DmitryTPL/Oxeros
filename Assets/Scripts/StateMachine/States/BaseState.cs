﻿using System;
using Cysharp.Threading.Tasks;
using Zenject;

namespace StateMachine
{
    public abstract class BaseState<TStateType> : IState<TStateType>
        where TStateType : Enum
    {
        public abstract TStateType State { get; }

        protected IPersistentData PersistentData { get; private set; }
        protected IPerUpdateData PerUpdateData { get; private set; }

        [Inject]
        private void AddDependencies(IPersistentData persistentData, IPerUpdateData perUpdateData)
        {
            PersistentData = persistentData;
            PerUpdateData = perUpdateData;
        }

        public virtual UniTask Enter()
        {
            return UniTask.CompletedTask;
        }

        public async UniTask<TStateType> Execute()
        {
            await HandleControl();

            return await TryMakeTransition();
        }

        protected virtual UniTask HandleControl()
        {
            return UniTask.CompletedTask;
        }

        protected virtual UniTask<TStateType> TryMakeTransition()
        {
            return new UniTask<TStateType>(State);
        }

        public virtual UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
    }
}