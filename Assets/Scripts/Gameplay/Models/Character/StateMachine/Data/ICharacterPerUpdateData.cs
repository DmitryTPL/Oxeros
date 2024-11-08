using StateMachine;
using UnityEngine;

namespace Gameplay
{
    public interface ICharacterPerUpdateData : IPerUpdateData
    {
        Vector3 LinearVelocity { get; set; }
    }
}