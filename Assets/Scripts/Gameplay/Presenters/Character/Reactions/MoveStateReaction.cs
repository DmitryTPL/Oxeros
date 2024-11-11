using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class MoveReactionPresenter : Presenter
    {
        private readonly IMoveReaction _reaction;

        private readonly AsyncReactiveProperty<Vector3> _accelerationChanged = new(default);

        public IReadOnlyAsyncReactiveProperty<Vector3> AccelerationChanged => _accelerationChanged;

        public MoveReactionPresenter()
        {
        }

        [Inject]
        public MoveReactionPresenter(IMoveReaction moveReaction)
        {
            moveReaction.Acceleration.WithoutCurrent().ForEachAsync(value => _accelerationChanged.Value = value, DestroyCancellationToken).Forget();
        }
    }
}