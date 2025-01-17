using Cysharp.Threading.Tasks;
using StateMachine;
using UnityEngine;

namespace Gameplay
{
    public interface ICharacterSharedData : ISharedData<CharacterState>
    {
        Transform Transform { get; set; }
    }
    
    public class CharacterSharedData : ICharacterSharedData
    {
        public AsyncReactiveProperty<CharacterState> CurrentState { get; set; } = new(default);
        public Transform Transform { get; set; }
    }
}