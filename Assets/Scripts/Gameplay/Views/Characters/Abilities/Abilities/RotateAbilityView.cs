using MVP;
using UnityEngine;

namespace Gameplay
{
    public class RotateAbilityView : View<RotateAbilityPresenter>
    {
        [SerializeField] private RotateAbilityPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}