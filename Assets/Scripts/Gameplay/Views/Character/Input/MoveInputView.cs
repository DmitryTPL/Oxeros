using MVP;
using UnityEngine;

namespace Gameplay
{
    public class MoveInputView : View<MoveInputPresenter>
    {
        [SerializeField] private BaseInputPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}