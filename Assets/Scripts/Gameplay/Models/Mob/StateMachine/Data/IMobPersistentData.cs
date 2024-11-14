using System;
using StateMachine;

namespace Gameplay
{
    public interface IMobPersistentData : IPersistentData
    {
        public Guid Guid { get; set; }
    }
}