using Cysharp.Threading.Tasks;
using Shared;

namespace Gameplay
{
    public interface ICharacterDeathHandler
    {
        IReadOnlyAsyncReactiveProperty<Invoker> CharacterDie { get; }
        
        void PutCharacterToDeath();
    }

    public class CharacterDeathHandler : ICharacterDeathHandler
    {
        private readonly AsyncReactiveProperty<Invoker> _characterDie = new(default);

        public IReadOnlyAsyncReactiveProperty<Invoker> CharacterDie => _characterDie;

        public void PutCharacterToDeath()
        {
            _characterDie.Invoke();
        }
    }
}