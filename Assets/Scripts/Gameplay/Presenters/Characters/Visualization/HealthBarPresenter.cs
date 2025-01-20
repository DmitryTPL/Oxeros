using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using Zenject;

namespace Gameplay
{
    public class HealthBarPresenter : Presenter
    {
        private readonly AsyncReactiveProperty<float> _healthPercent = new(default);

        public IReadOnlyAsyncReactiveProperty<float> HealthPercent => _healthPercent;

        public HealthBarPresenter() { }

        [Inject]
        public HealthBarPresenter(IHealthHandler healthHandler)
        {
            healthHandler.Health.ForEachAsync(h => _healthPercent.Value = h / healthHandler.MaxHealth.Value, DestroyCancellationToken).Forget();
        }
    }
}