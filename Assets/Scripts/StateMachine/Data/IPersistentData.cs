using System;

namespace StateMachine
{
    public interface IPersistentData
    {
        Guid Guid { get; set; }
    }
}