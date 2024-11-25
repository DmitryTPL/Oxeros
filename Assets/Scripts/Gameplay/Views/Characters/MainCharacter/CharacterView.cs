using MVP;
using UnityEngine;

namespace Gameplay
{
    public class CharacterView : View<CharacterPresenter>
    {
        [SerializeField] private CharacterPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}