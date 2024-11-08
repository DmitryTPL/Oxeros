using System;
using AYellowpaper.SerializedCollections;

namespace Gameplay
{
    [Serializable]
    public class CharacterStateToTransitionsDictionary : SerializedDictionary<CharacterState, CharacterTransitionsList>
    {
    }
}