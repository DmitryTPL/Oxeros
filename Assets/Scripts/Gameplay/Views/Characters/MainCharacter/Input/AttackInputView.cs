using MVP;
using UnityEngine;

namespace Gameplay
{
    public class AttackInputView : View<AttackInputPresenter>
    {
        [SerializeField] private InputPresenterViewSharedData _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}