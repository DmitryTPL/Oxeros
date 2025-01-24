using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "MobConfig", menuName = "ScriptableObjects/Mob/MobConfig", order = 0)]
    public class MobConfig : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField] private float _maxSpeed = 1;
        [SerializeField] private float _acceleration = 20;
        [SerializeField] private float _maxAcceleration = 100;
        [SerializeField] private float _rotationSpeed = 100;
        [SerializeField] private float _rotationDamper = 0.5f;
        [SerializeField] private float _minDistanceToApproach = 5f;

        [Header("Roam")]
        [SerializeField] private float _roamingMaxSpeed = 1;

        [Header("Attack")]
        [SerializeField] private float _attackDistance = 1;

        [Header("Heath")]
        [SerializeField] private float _health = 1;

        public float MaxSpeed => _maxSpeed;
        public float Acceleration => _acceleration;
        public float MaxAcceleration => _maxAcceleration;
        public float RotationSpeed => _rotationSpeed;
        public float RotationDamper => _rotationDamper;
        public float RoamingMaxSpeed => _roamingMaxSpeed;
        public float AttackDistance => _attackDistance;
        public float Health => _health;
        public float MinDistanceToApproach => _minDistanceToApproach;
    }
}