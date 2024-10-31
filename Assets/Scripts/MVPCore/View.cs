using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace MVP
{
    public abstract class View<TPresenter> : MonoBehaviour, IView
        where TPresenter : Presenter, new()
    {
        [SerializeField] [ReadOnly] private string _guid;

        private TPresenter _presenter;

        protected TPresenter Presenter
        {
            get
            {
#if UNITY_EDITOR
                if (_presenter == null && !Application.isPlaying)
                {
                    _presenter = new TPresenter();
                    _guid = _presenter.Guid.ToString();

                    TryUpdateSharedData();
                }
#endif

                return _presenter;
            }
        }

        public Guid Guid => Presenter.Guid;

        protected virtual PresenterViewSharedData SharedData { get; private set; }

        [Inject]
        public void Constructor(TPresenter presenter)
        {
            _presenter = presenter;

            _guid = presenter.Guid.ToString();

            gameObject.GetCancellationTokenOnDestroy().Register(presenter.InvokeDestroyCancellationToken);

            TryUpdateSharedData();

            _presenter.InitializationCompleted += CompleteInitialization;

            void CompleteInitialization()
            {
                _presenter.InitializationCompleted -= CompleteInitialization;

                PresenterAttached();
            }
        }

        private void TryUpdateSharedData()
        {
            if (Presenter == null)
            {
                return;
            }

            if (SharedData == null)
            {
                var tempSharedData = new PresenterViewSharedData
                {
                    Transform = transform
                };

                Presenter.SetSharedData(tempSharedData);
            }
            else
            {
                SharedData.Transform = transform;

                Presenter.SetSharedData(SharedData);
            }
        }

        protected virtual void PresenterAttached()
        {
        }

        protected virtual void OnEnable()
        {
            Presenter?.OnEnable();
        }

        protected virtual void OnDisable()
        {
            Presenter?.OnDisable();
        }

        protected virtual void OnDestroy()
        {
            _presenter?.Dispose();
            _presenter = null;
        }

        protected virtual void OnValidate()
        {
            TryUpdateSharedData();
            Presenter?.OnValidate();
        }
    }
}