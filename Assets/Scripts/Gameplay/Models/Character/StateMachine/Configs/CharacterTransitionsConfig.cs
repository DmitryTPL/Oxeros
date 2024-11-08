using StateMachine;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "CharacterTransitionsConfig", menuName = "ScriptableObjects/Character/CharacterTransitionsConfig", order = 2)]
    public class CharacterTransitionsConfig :
        BaseTransitionsConfig<
            CharacterState,
            CharacterTransition,
            CharacterTransitionActivity,
            CharacterStatesList,
            CharacterTransitionsList,
            CharacterStateToTransitionsDictionary,
            CharacterTransitionToStatesDictionary>
    {
    }
}