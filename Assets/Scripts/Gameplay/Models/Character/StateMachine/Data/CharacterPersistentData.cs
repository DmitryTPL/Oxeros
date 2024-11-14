using System;
using StateMachine;
using UnityEngine;

namespace Gameplay
{
    public interface ICharacterPersistentData : IPersistentData
    {
        Vector3 GoalVelocity { get; set; }
        bool IsDefending { get; set; }
    }

    public class CharacterPersistentData : ICharacterPersistentData
    {
        public Guid Guid { get; set; }
        public Vector3 GoalVelocity { get; set; }
        public bool IsDefending { get; set; }
    }
}