using System;
using AYellowpaper.SerializedCollections;

namespace Gameplay
{
    [Serializable]
    public class CharacterTransitionToStatesDictionary : SerializedDictionary<CharacterTransition, CharacterStatesList>
    {
    }
}