using MVP;
using UnityEngine;

namespace Gameplay
{
    public class NoticeEnemyAbilityView : View<NoticeEnemyAbilityPresenter>
    {
        [SerializeField] private NoticeEnemyAbilityPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}