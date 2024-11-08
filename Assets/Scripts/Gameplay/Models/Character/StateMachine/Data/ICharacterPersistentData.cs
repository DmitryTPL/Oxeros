using StateMachine;
using UnityEngine;

namespace Gameplay
{
    public interface ICharacterPersistentData : IPersistentData
    {
        Vector3 GoalVelocity { get; set; }
    }
}