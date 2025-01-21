using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public interface IDefenceHandler
    {
        IReadOnlyAsyncReactiveProperty<bool> IsDefending { get; }
        void SetDefendingState(bool isDefending);
    }

    public class DefenceHandler : IDefenceHandler
    {
        private readonly AsyncReactiveProperty<bool> _isDefending = new(default);

        public IReadOnlyAsyncReactiveProperty<bool> IsDefending => _isDefending;

        public void SetDefendingState(bool isDefending)
        {
            _isDefending.Value = isDefending;
        }
    }
}