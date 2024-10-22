using System;
using System.Threading;
using Zenject;

namespace MVP
{
    public abstract class Presenter : IPresenter
    {
        private PresenterViewSharedData _sharedData;

        public event Action InitializationCompleted;

        public Guid Guid { get; }

        public CancellationToken DestroyCancellationToken { get; set; }

        protected bool IsEnable { get; private set; }

        protected Presenter()
        {
            Guid = Guid.NewGuid();
        }

        void IInitializable.Initialize()
        {
            InitializationCompleted?.Invoke();
            InitializeData();
        }

        public virtual void OnEnable()
        {
            IsEnable = true;
        }

        public virtual void OnDisable()
        {
            IsEnable = false;
        }

        public virtual void OnValidate()
        {
        }

        protected virtual void InitializeData()
        {
        }

        protected TData GetSharedData<TData>()
            where TData : PresenterViewSharedData
        {
            return (TData)_sharedData;
        }

        public void SetSharedData<TData>(TData data)
            where TData : PresenterViewSharedData
        {
            _sharedData = data;
        }

        public override bool Equals(object obj)
        {
            return obj is Presenter presenter && Equals(presenter);
        }

        protected bool Equals(Presenter other)
        {
            return Equals(other.Guid);
        }

        protected bool Equals(Guid guid)
        {
            return Guid.Equals(guid);
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }

        public void Dispose()
        {
            Disposed();
        }

        protected virtual void Disposed()
        {
        }
    }
}