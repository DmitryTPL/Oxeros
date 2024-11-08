using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public class CharacterSharedData : ICharacterSharedData
    {
        public AsyncReactiveProperty<CharacterState> CurrentState { get; set; } = new(default);
    }
}