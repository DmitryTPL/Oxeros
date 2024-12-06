using System.Collections.Generic;
using System.Linq;

namespace Gameplay
{
    public interface IHitHandler
    {
        void ProcessHit(IEnumerable<HitData> hitInfo);
    }

    public class HitHandler : IHitHandler
    {
        private readonly IDictionary<DamageType, IDamageTypeHandler> _damageHandlers;
        private readonly IHealthHandler _healthHandler;

        public HitHandler(IEnumerable<IDamageTypeHandler> damageHandlers, IHealthHandler healthHandler)
        {
            _damageHandlers = damageHandlers.ToDictionary(h => h.DamageType);
            _healthHandler = healthHandler;
        }

        public void ProcessHit(IEnumerable<HitData> hitInfo)
        {
            foreach (var hit in hitInfo)
            {
                _healthHandler.Damage(_damageHandlers[hit.DamageType].Process(hit.Damage));
            }
        }
    }
}