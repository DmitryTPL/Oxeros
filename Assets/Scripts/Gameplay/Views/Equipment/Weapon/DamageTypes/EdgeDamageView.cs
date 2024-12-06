using MVP;
using UnityEngine;

namespace Gameplay
{
    public class EdgeDamageView : View<EdgeDamagePresenter>
    {
        [SerializeField] private DamageTypePresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}