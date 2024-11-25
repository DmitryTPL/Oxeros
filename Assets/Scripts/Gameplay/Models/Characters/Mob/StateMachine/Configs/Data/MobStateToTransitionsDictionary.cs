using System;
using AYellowpaper.SerializedCollections;

namespace Gameplay
{
    [Serializable]
    public class MobStateToTransitionsDictionary : SerializedDictionary<MobState, MobTransitionsList>
    {
    }
}