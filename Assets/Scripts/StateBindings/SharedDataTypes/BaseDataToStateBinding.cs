using System;
using EditorAttributes;
using UnityEngine;

namespace StateBindings
{
    [Serializable]
    public class BaseDataToStateBinding<TData, TStateType>
        where TStateType : Enum
    {
        [HideInInspector, Rename(nameof(_state), stringInputMode: StringInputMode.Dynamic)]
        public string name;

        [SerializeField] private TStateType _state;
        [SerializeField] private TData _data;

        public TStateType State => _state;
        public TData Data => _data;
    }
}