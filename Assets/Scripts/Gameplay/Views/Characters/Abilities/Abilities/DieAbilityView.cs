using MVP;
using UnityEngine;

namespace Gameplay
{
    public class DieAbilityView : View<DieAbilityPresenter>
    {
        [SerializeField] private DieAbilityPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}