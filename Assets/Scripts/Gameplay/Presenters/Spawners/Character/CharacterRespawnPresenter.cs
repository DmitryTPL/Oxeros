using System;
using Cinemachine;
using EditorAttributes;
using MVP;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CharacterRespawnPresenter : Presenter
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private bool _isFirstSpawn;
            [SerializeField] [ShowField(nameof(_isFirstSpawn))] private GameObject _characterPrefab;
            [SerializeField] [TagField] private string _expectedCollider;

            public GameObject CharacterPrefab => _characterPrefab;
            public bool IsFirstSpawn => _isFirstSpawn;
            public string ExpectedCollider => _expectedCollider;
        }

        private readonly IViewFactory _viewFactory;
        private readonly IRespawnHandler _respawnHandler;
        private Data _data;

        public CharacterRespawnPresenter() { }

        [Inject]
        public CharacterRespawnPresenter(IViewFactory viewFactory, IRespawnHandler respawnHandler)
        {
            _viewFactory = viewFactory;
            _respawnHandler = respawnHandler;
        }

        protected override void InitializeData()
        {
            base.InitializeData();

            _data = GetSharedData<Data>();

            if (_data.IsFirstSpawn)
            {
                var character = _viewFactory.Create(_data.CharacterPrefab);

                character.transform.position = _data.Transform.position;

                _respawnHandler.FinishFirstSpawn(character.transform);
            }
        }

        public void ColliderEnter(Collider collider)
        {
            if (!collider.gameObject.CompareTag(_data.ExpectedCollider))
            {
                return;
            }

            _respawnHandler.LastActiveRespawnPosition = _data.Transform.position;
        }
    }
}