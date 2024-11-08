using System;
using UnityEngine;

namespace Gameplay
{
    public class CharacterPersistentData : ICharacterPersistentData
    {
        public Guid Guid { get; set; }
        public Vector3 GoalVelocity { get; set; }
    }
}