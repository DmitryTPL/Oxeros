namespace Gameplay
{
    public struct HitData
    {
        public DamageType DamageType { get; }
        public float Damage { get; }

        public HitData(DamageType damageType, float damage)
        {
            DamageType = damageType;
            Damage = damage;
        }
    }
}