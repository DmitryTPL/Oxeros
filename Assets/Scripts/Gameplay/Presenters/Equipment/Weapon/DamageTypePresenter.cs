using System;
using MVP;
using UnityEngine;

namespace Gameplay
{
    public interface IDamageInfoProvider
    {
        public HitData HitData { get; }
    }

    public abstract class DamageTypePresenter : Presenter, IDamageInfoProvider
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private float _damage;

            public float Damage => _damage;
        }

        protected abstract DamageType DamageType { get; }

        public HitData HitData => new(DamageType, GetSharedData<Data>().Damage);
    }
}