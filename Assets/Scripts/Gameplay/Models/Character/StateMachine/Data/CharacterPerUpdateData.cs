using UnityEngine;

namespace Gameplay
{
    public class CharacterPerUpdateData : ICharacterPerUpdateData
    {
        public Vector3 LinearVelocity { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 AngularVelocity { get; set; }
    }
}