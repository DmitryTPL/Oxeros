using System.Collections.Generic;
using MVP;
using Zenject;

namespace Gameplay
{
    public class DamageReceiverPresenter : Presenter
    {
        private readonly IHitHandler _hitHandler;

        public DamageReceiverPresenter()
        {
        }

        [Inject]
        public DamageReceiverPresenter(IHitHandler hitHandler)
        {
            _hitHandler = hitHandler;
        }

        public void ReceiveDamage(IEnumerable<HitData> hitInfo)
        {
            _hitHandler.ProcessHit(hitInfo);
        }
    }
}