using MVP;
using StateMachine;
using UnityEngine;

namespace Gameplay
{
    public class CharacterView : StateViewBase<CharacterPresenter, ICharacterStateResult, CharacterState>
    {
        [SerializeField] private CharacterPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}