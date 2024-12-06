using System.Collections.Generic;

namespace Gameplay
{
    public interface IDamageReceiver
    {
        void ReceiveDamage(IEnumerable<HitData> hitInfo);
    }
}