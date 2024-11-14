using System;
using StateMachine;
using UnityEngine;

namespace Gameplay
{
    [Serializable, CreateAssetMenu(fileName = "MobStateTimeConfig", menuName = "ScriptableObjects/Mob/MobStateTimeConfig", order = 1)]
    public class MobStateTimeConfig : BaseStateTimeConfig<MobState, MobStateToTimeDictionary>
    {
    }
}