using System;
using Cysharp.Threading.Tasks;

namespace StateMachine
{
    public interface ISharedData<TStateType>
        where TStateType : Enum
    {
        AsyncReactiveProperty<TStateType> CurrentState { get; set; }
    }
}