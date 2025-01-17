using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using Cysharp.Threading.Tasks.Triggers;
using MVP;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Collider))]
    public class CharacterRespawnView : View<CharacterRespawnPresenter>
    {
        [SerializeField] private CharacterRespawnPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;

        protected override void PresenterAttached()
        {
            base.PresenterAttached();

            this.GetAsyncTriggerEnterTrigger().ForEachAsync(Presenter.ColliderEnter, destroyCancellationToken).Forget();
        }
    }
}