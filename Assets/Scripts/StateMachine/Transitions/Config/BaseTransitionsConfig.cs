using System;
using System.Collections.Generic;
using System.Linq;
using EditorAttributes;
using UnityEngine;

namespace StateMachine
{
    public interface ITransitionsConfig<TStateType, TTransitionType>
        where TStateType : Enum
        where TTransitionType : Enum
    {
        IEnumerable<TTransitionType> GetTransitions(TStateType state);
        bool ContainsState(TStateType state);
        IEnumerable<TTransitionType> GetActiveTransitions();
        bool ContainsTransition(TTransitionType transition);
        List<TStateType> GetStatesForTransition(TTransitionType transition);
        bool CanTransitionInterruptStateTiming(TStateType currentState, TTransitionType interruptingTransition);
    }

    public abstract class BaseTransitionsConfig<TStateType, TTransitionType, TTransitionActivity, TStatesList, TTransitionsList, TStateToTransitionsDictionary, TTransitionToStateDictionary> :
        ScriptableObject, ITransitionsConfig<TStateType, TTransitionType>
        where TStateType : Enum
        where TTransitionType : Enum
        where TTransitionActivity : ITransitionActivity<TTransitionType>
        where TStatesList : BaseStatesList<TStateType>, new()
        where TTransitionsList : BaseTransitionsList<TTransitionType>, new()
        where TStateToTransitionsDictionary : UnitySerializedDictionary<TStateType, TTransitionsList>
        where TTransitionToStateDictionary : UnitySerializedDictionary<TTransitionType, TStatesList>
    {
        [SerializeField, VerticalGroup("Transitions")] private TTransitionActivity _transitionsActivity;
        [SerializeField, VerticalGroup("Transitions")] private TStateToTransitionsDictionary _states;
        [SerializeField, VerticalGroup("Transitions")] private TStateToTransitionsDictionary _stateInterruptedByTransitions;
        [SerializeField] [HideInInspector] private TTransitionToStateDictionary _transitions;

        [VerticalGroup("Add Transition")]
        [SerializeField] private List<TStateType> _statesForAdd;

        [VerticalGroup("Add Transition")]
        [SerializeField] private TTransitionType _transitionForAdd;

        [VerticalGroup("Remove Transition")]
        [SerializeField] private TTransitionType _transitionForRemove;

        public IEnumerable<TTransitionType> GetTransitions(TStateType state)
        {
            return _states[state].UsedTransitions;
        }

        public bool ContainsState(TStateType state)
        {
            return _states.ContainsKey(state);
        }

        public IEnumerable<TTransitionType> GetActiveTransitions()
        {
            return _transitionsActivity.GetActiveTransitions();
        }

        public bool ContainsTransition(TTransitionType transition)
        {
            return _transitions.ContainsKey(transition);
        }

        public List<TStateType> GetStatesForTransition(TTransitionType transition)
        {
            return _transitions[transition].UsedInStates;
        }

        public bool CanTransitionInterruptStateTiming(TStateType currentState, TTransitionType interruptingTransition)
        {
            return _stateInterruptedByTransitions.ContainsKey(currentState) && _stateInterruptedByTransitions[currentState].UsedTransitions.Contains(interruptingTransition);
        }

        [Button]
        private void RemoveTransitionFromAllStates()
        {
            if (_transitionForRemove == null)
            {
                return;
            }

            foreach (var stateKeyValue in _states)
            {
                stateKeyValue.Value.RemoveTransition(_transitionForRemove);
            }

            SyncTransitionsToStateCache();
            _transitionForRemove = default;
        }

        [Button]
        private void ClearStates()
        {
            _statesForAdd.Clear();
        }

        [Button, GUIColor(0, 1, 0)]
        private void AddTransitionToStates()
        {
            foreach (var characterState in _statesForAdd)
            {
                if (!_states.ContainsKey(characterState))
                {
                    _states.Add(characterState, new TTransitionsList());
                }

                _states[characterState].AddTransition(_transitionForAdd);
            }

            SyncTransitionsToStateCache();

            _statesForAdd.Clear();
            _transitionForAdd = default;
        }

        [Button, GUIColor(1, 0, 0)]
        public void SyncTransitionsToStateCache()
        {
            _transitions.Clear();

            foreach (var state in _states)
            {
                foreach (var transition in state.Value.UsedTransitions)
                {
                    if (!_transitions.ContainsKey(transition))
                    {
                        var list = new TStatesList
                        {
                            UsedInStates = new List<TStateType>()
                        };

                        _transitions.Add(transition, list);
                    }

                    _transitions[transition].UsedInStates.Add(state.Key);
                }
            }

            Debug.Log("Transitions toStateCache synchronized");

            CheckTransitionForNonExistsState();
        }

        #region CheckingOnInspector

        private List<TTransitionType> _transitionsWithoutState = new();
        private bool HasError => _transitionsWithoutState.Count > 0;
        private string ErrorText => "Exit from state of this Transitions doesn't exists:\n" + string.Join(",", _transitionsWithoutState.Select(id => id.ToString()));

        private void CheckTransitionForNonExistsState()
        {
            var transitions = _transitions.Keys.ToList();
            var states = new HashSet<string>(_states.Keys.Select(item => item.ToString()));

            _transitionsWithoutState.Clear();

            foreach (var transition in transitions.Where(transition => !states.Contains(transition.ToString())))
            {
                _transitionsWithoutState.Add(transition);
            }
        }

        #endregion
    }
}