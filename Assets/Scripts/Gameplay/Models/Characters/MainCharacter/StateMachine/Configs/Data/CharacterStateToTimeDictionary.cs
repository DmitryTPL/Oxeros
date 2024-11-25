using System;
using AYellowpaper.SerializedCollections;

namespace Gameplay
{
    [Serializable]
    public class CharacterStateToTimeDictionary : SerializedDictionary<CharacterState, float>
    {
    }
}