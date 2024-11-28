using StateMachine;
using UnityEngine;

namespace Gameplay
{
    public interface IMobPerUpdateData : IPerUpdateData
    {
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
        Vector3 LinearVelocity { get; set; }
        Vector3 AngularVelocity { get; set; }
    }

    public class MobPerUpdateData : IMobPerUpdateData
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 LinearVelocity { get; set; }
        public Vector3 AngularVelocity { get; set; }
    }
}