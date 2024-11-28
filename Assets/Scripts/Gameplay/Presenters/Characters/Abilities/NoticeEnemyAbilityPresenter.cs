using System;
using Cinemachine;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using Cysharp.Threading.Tasks.Triggers;
using MVP;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class NoticeEnemyAbilityPresenter : Presenter
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [TagField] [SerializeField] private string _expectedObjectTag;
            [SerializeField] private Collider _areaCollider;
            [SerializeField] private Transform _eyesPosition;

            public Collider AreaCollider => _areaCollider;
            public string ExpectedObjectTag => _expectedObjectTag;
            public Vector3 EyesPosition => _eyesPosition != null ? _eyesPosition.position : Vector3.zero;
        }

        private readonly INoticeEnemyArea _area;
        private Data _data;

        public NoticeEnemyAbilityPresenter() { }

        [Inject]
        public NoticeEnemyAbilityPresenter(INoticeEnemyArea area)
        {
            _area = area;
        }

        protected override void InitializeData()
        {
            base.InitializeData();

            _data = GetSharedData<Data>();

            _data.AreaCollider.GetAsyncTriggerEnterTrigger().ForEachAsync(OnTriggerEnter, DestroyCancellationToken).Forget();
            _data.AreaCollider.GetAsyncTriggerExitTrigger().ForEachAsync(OnTriggerExit, DestroyCancellationToken).Forget();
        }

        private void OnTriggerEnter(Collider enterObject)
        {
            if (enterObject.gameObject.CompareTag(_data.ExpectedObjectTag))
            {
                if (_data.EyesPosition != Vector3.zero)
                {
                    var distance = enterObject.bounds.center - _data.EyesPosition;

                    var isHit = Physics.Raycast(
                        _data.EyesPosition,
                        distance.normalized,
                        out _,
                        distance.magnitude);

                    if (isHit)
                    {
                        _area.NoticeEnemy(enterObject.transform);
                    }
                }
                else
                {
                    _area.NoticeEnemy(enterObject.transform);
                }
            }
        }

        private void OnTriggerExit(Collider exitObject)
        {
            if (exitObject.gameObject.CompareTag(_data.ExpectedObjectTag))
            {
                _area.EnemyLeave();
            }
        }
    }
}