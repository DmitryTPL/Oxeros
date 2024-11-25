using System;
using StateMachine;
using UnityEngine;

namespace Gameplay
{
    public interface IMobPersistentData : IPersistentData
    {
        Vector3 RoamPathStart { get; set; }
        Vector3 RoamPathDestination { get; set; }
        Vector3 RoamPathDirection { get; set; }
        bool RoamMoveOnPathFinished { get; set; }
        bool RoamRotationFinished { get; set; }
    }
    
    public class MobPersistentData : IMobPersistentData
    {
        public Guid Guid { get; set; }
        public Vector3 RoamPathStart { get; set; }
        public Vector3 RoamPathDestination { get; set; }
        public Vector3 RoamPathDirection { get; set; }
        public bool RoamMoveOnPathFinished { get; set; }
        public bool RoamRotationFinished { get; set; }
    }
}