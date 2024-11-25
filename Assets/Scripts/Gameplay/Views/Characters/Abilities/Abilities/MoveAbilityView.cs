using MVP;
using UnityEngine;

namespace Gameplay
{
    public class MoveAbilityView : View<MoveAbilityPresenter>
    {
        [SerializeField] private MoveAbilityPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}