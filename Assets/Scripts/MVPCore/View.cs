using System;
using System.Threading;
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
        private bool _isEnabled;

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
        
        // ReSharper disable once InconsistentNaming
        public new CancellationToken destroyCancellationToken => gameObject.GetCancellationTokenOnDestroy();

        [Inject]
        public void Constructor(TPresenter presenter)
        {
            _presenter = presenter;

            if (_isEnabled)
            {
                _presenter.OnEnable();
            }
            else
            {
                _presenter.OnDisable();
            }

            _guid = presenter.Guid.ToString();

            destroyCancellationToken.Register(presenter.InvokeDestroyCancellationToken);

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
            if (Presenter == null)
            {
                _isEnabled = true;
            }
            else
            {
                Presenter.OnEnable();
            }
        }

        protected virtual void OnDisable()
        {
            if (Presenter == null)
            {
                _isEnabled = false;
            }
            else
            {
                Presenter.OnDisable();
            }
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