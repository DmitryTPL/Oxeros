using UnityEngine;

namespace Gameplay
{
    public interface IDamageTypeHandler
    {
        DamageType DamageType { get; }

        float Process(float damage, float resistance = 0);
    }

    public abstract class BaseDamageTypeHandler : IDamageTypeHandler
    {
        public abstract DamageType DamageType { get; }

        public float Process(float damage, float resistance = 0)
        {
            return Mathf.Max(damage - resistance, 0);
        }
    }
}