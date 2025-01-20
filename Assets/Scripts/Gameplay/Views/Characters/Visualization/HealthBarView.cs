using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class HealthBarView : View<HealthBarPresenter>
    {
        [SerializeField] private Image _health;

        private float _nextValue;

        protected override void PresenterAttached()
        {
            base.PresenterAttached();

            Presenter.HealthPercent.ForEachAsync(HealthChanged, destroyCancellationToken).Forget();
        }

        private void HealthChanged(float value)
        {
            _nextValue = value;
        }

        private void Update()
        {
            var delta = _nextValue - _health.fillAmount;

            if (Math.Abs(delta) <= float.Epsilon)
            {
                return;
            }

            var sign = Math.Sign(delta);

            var change = Math.Min(Math.Abs(delta), Time.deltaTime);

            var currentAmount = _health.fillAmount;

            currentAmount += sign * change;

            _health.fillAmount = currentAmount;
        }
    }
}