using System;
using StateMachine;

namespace Gameplay
{
    public interface ICharacterPersistentData : IPersistentData
    {
    }

    public class CharacterPersistentData : ICharacterPersistentData
    {
        public Guid Guid { get; set; }
    }
}