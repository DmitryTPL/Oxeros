using StateMachine;
using UnityEngine;

namespace Gameplay
{
    public interface ICharacterPerUpdateData : IPerUpdateData
    {
        Vector3 LinearVelocity { get; set; }
        Quaternion Rotation { get; set; }
        Vector3 AngularVelocity { get; set; }
    }
}