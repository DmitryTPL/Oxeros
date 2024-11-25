using MVP;
using UnityEngine;

namespace Gameplay
{
    public class MobView : View<MobPresenter>
    {
        [SerializeField] private MobPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}