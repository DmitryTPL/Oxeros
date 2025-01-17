using MVP;
using UnityEngine;

namespace Gameplay
{
    public class RespawnAbilityView : View<RespawnAbilityPresenter>
    {
        [SerializeField] private RespawnAbilityPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}