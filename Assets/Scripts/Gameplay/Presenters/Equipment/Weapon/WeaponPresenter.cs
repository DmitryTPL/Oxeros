﻿using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponPresenter : Presenter
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private Collider _collider;

            public Collider Collider => _collider;
        }

        private readonly IEnumerable<HitData> _damageInfo;
        private Data _data;

        public WeaponPresenter()
        {
        }

        [Inject]
        public WeaponPresenter(IAttackAbility attackAbility, IEnumerable<IDamageInfoProvider> damageProviders)
        {
            _damageInfo = damageProviders.Select(dp => dp.HitData);

            attackAbility.AttackBegin.WithoutCurrent().ForEachAsync(AttackBegin, DestroyCancellationToken).Forget();
            attackAbility.AttackEnd.WithoutCurrent().ForEachAsync(AttackEnd, DestroyCancellationToken).Forget();
        }

        protected override void InitializeData()
        {
            base.InitializeData();

            _data = GetSharedData<Data>();

            _data.Collider.enabled = false;
        }

        private void AttackBegin(bool _)
        {
            _data.Collider.enabled = true;
        }

        private void AttackEnd(bool _)
        {
            _data.Collider.enabled = false;
        }

        public void TriggerEnter(Collider collider)
        {
            if (collider.gameObject.GetComponentsInChildren<IDamageBlocker>().Length > 0)
            {
                _data.Collider.enabled = false;
                return;
            }

            var damageReceivers = collider.gameObject.GetComponentsInChildren<IDamageReceiver>();

            if (damageReceivers.Length > 0)
            {
                damageReceivers[0].ReceiveDamage(_damageInfo);
                _data.Collider.enabled = false;
            }
        }
    }
}