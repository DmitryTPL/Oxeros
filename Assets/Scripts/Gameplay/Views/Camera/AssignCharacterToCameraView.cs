using MVP;
using UnityEngine;

namespace Gameplay
{
    public class AssignCharacterToCameraView : View<AssignCharacterToCameraPresenter>
    {
        [SerializeField] private AssignCharacterToCameraPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}