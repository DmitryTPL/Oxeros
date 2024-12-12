using MVP;
using UnityEngine;

namespace Gameplay
{
    public class ShieldPointView : View<ShieldPointPresenter>
    {
        [SerializeField] private EquipmentPointPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}