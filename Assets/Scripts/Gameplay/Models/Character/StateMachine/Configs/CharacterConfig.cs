using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "ScriptableObjects/Character/CharacterConfig", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [Header("Gravity")]
        [SerializeField] private float _gravitationFactor;

        [Header("Movement")]
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxAcceleration;

        public float GravitationFactor => _gravitationFactor;
        public float MaxSpeed => _maxSpeed;
        public float Acceleration => _acceleration;
        public float MaxAcceleration => _maxAcceleration;
    }
}