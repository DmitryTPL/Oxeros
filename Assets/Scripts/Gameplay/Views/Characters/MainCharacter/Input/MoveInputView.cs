using MVP;
using UnityEngine;

namespace Gameplay
{
    public class MoveInputView : View<MoveInputPresenter>
    {
        [SerializeField] private InputPresenterViewSharedData _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}