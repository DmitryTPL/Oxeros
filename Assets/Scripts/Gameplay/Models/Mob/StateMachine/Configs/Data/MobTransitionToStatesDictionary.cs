using System;
using AYellowpaper.SerializedCollections;

namespace Gameplay
{
    [Serializable]
    public class MobTransitionToStatesDictionary : SerializedDictionary<MobTransition, MobStatesList>
    {
    }
}