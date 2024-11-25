using MVP;
using UnityEngine;

namespace Gameplay
{
    public class RoamAbilityView : View<RoamAbilityPresenter>
    {
        [SerializeField] private RoamAbilityPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}