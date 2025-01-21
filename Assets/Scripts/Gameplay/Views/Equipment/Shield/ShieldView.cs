using MVP;
using UnityEngine;

namespace Gameplay
{
    public class ShieldView : View<ShieldPresenter>
    {
        [SerializeField] private ShieldPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}