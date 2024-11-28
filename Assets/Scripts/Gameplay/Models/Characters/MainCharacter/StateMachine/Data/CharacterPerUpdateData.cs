using StateMachine;
using UnityEngine;

namespace Gameplay
{
    public interface ICharacterPerUpdateData : IPerUpdateData
    {
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
        Vector3 LinearVelocity { get; set; }
        Vector3 AngularVelocity { get; set; }
    }
    
    public class CharacterPerUpdateData : ICharacterPerUpdateData
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 AngularVelocity { get; set; }
        public Vector3 LinearVelocity { get; set; }
    }
}