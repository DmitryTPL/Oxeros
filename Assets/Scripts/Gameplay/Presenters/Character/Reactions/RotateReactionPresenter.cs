using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class RotateReactionPresenter : Presenter
    {
        private readonly AsyncReactiveProperty<Vector3> _rotation = new(default);

        private readonly AsyncReactiveProperty<bool> _stop = new(default);

        public IReadOnlyAsyncReactiveProperty<Vector3> Rotation => _rotation;
        public IReadOnlyAsyncReactiveProperty<bool> Stop => _stop;

        public RotateReactionPresenter() { }

        [Inject]
        public RotateReactionPresenter(IRotateReaction rotateReaction)
        {
            rotateReaction.Rotation.WithoutCurrent().ForEachAsync(r => _rotation.Value = r).Forget();
            rotateReaction.Stop.WithoutCurrent().ForEachAsync(_ => _stop.Value = true).Forget();
        }
    }
}