using System;
using StateMachine;
using UnityEngine;

namespace Gameplay
{
    [Serializable, CreateAssetMenu(fileName = "CharacterStateTimeConfig", menuName = "ScriptableObjects/Character/CharacterStateTimeConfig", order = 1)]
    public class CharacterStateTimeConfig : BaseStateTimeConfig<CharacterState, CharacterStateToTimeDictionary>
    {
    }
}