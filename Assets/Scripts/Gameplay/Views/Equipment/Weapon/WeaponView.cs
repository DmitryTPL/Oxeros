using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using Cysharp.Threading.Tasks.Triggers;
using MVP;
using UnityEngine;

namespace Gameplay
{
    public class WeaponView : View<WeaponPresenter>
    {
        [SerializeField] private WeaponPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;

        protected override void PresenterAttached()
        {
            this.GetAsyncTriggerEnterTrigger().ForEachAsync(Presenter.TriggerEnter, destroyCancellationToken).Forget();
        }
    }
}