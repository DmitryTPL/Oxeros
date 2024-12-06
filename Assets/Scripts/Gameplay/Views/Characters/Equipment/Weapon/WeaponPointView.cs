using MVP;
using UnityEngine;

namespace Gameplay
{
    public class WeaponPointView : View<WeaponPointPresenter>
    {
        [SerializeField] private WeaponPointPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}