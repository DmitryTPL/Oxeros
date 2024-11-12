using MVP;
using UnityEngine;

namespace Gameplay
{
    public class DefenceInputView : View<DefenceInputPresenter>
    {
        [SerializeField] private InputPresenterViewSharedData _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}