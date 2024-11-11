using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using UnityEngine;

namespace Gameplay
{
    public class RotateReactionView : View<RotateReactionPresenter>
    {
        [SerializeField] private Rigidbody _rigidbody;

        protected override void PresenterAttached()
        {
            Presenter.Rotation.WithoutCurrent().ForEachAsync(RotationChanged, destroyCancellationToken).Forget();
            Presenter.Stop.WithoutCurrent().ForEachAsync(StopRotation, destroyCancellationToken).Forget();
        }

        private void StopRotation(bool _)
        {
            _rigidbody.angularVelocity = Vector3.zero;
        }

        private void RotationChanged(Vector3 rotationChange)
        {
            _rigidbody.AddTorque(rotationChange);
        }
    }
}