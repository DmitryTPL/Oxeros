using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using UnityEngine;

namespace Gameplay
{
    public class MoveStateReactionView : View<MoveStateReactionPresenter>
    {
        [SerializeField] private Rigidbody _rigidbody;

        protected override void PresenterAttached()
        {
            Presenter.AccelerationChanged.WithoutCurrent().ForEachAsync(AccelerationChanged, destroyCancellationToken).Forget();
        }

        private void AccelerationChanged(Vector3 acceleration)
        {
            _rigidbody.AddForce(acceleration, ForceMode.VelocityChange);
        }
    }
}