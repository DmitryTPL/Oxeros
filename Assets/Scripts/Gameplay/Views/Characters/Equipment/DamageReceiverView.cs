using System.Collections.Generic;
using MVP;

namespace Gameplay
{
    public class DamageReceiverView : View<DamageReceiverPresenter>, IDamageReceiver
    {
        public void ReceiveDamage(IEnumerable<HitData> hitInfo)
        {
            Presenter.ReceiveDamage(hitInfo);
        }
    }
}