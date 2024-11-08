using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class MoveStateReactionPresenter : Presenter
    {
        private readonly IMoveStateReaction _stateReaction;

        private readonly AsyncReactiveProperty<Vector3> _accelerationChanged = new(default);

        public IReadOnlyAsyncReactiveProperty<Vector3> AccelerationChanged => _accelerationChanged;

        public MoveStateReactionPresenter()
        {
        }

        [Inject]
        public MoveStateReactionPresenter(IMoveStateReaction stateReaction)
        {
            stateReaction.Acceleration.WithoutCurrent().ForEachAsync(value => _accelerationChanged.Value = value, DestroyCancellationToken).Forget();
        }
    }
}