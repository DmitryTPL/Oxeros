using Cysharp.Threading.Tasks;
using StateMachine;

namespace Gameplay
{
    public interface ICharacterSharedData : ISharedData<CharacterState>
    {
        
    }
    
    public class CharacterSharedData : ICharacterSharedData
    {
        public AsyncReactiveProperty<CharacterState> CurrentState { get; set; } = new(default);
    }
}