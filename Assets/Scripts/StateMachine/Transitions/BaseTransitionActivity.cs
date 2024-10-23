using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace StateMachine
{
    public interface ITransitionActivity<out TTransitionType>
        where TTransitionType : Enum
    {
        IEnumerable<TTransitionType> GetActiveTransitions();
    }
    
    public abstract class BaseTransitionActivity<TTransitionType> : ITransitionActivity<TTransitionType>
        where TTransitionType : Enum
    {
        protected interface ITransitionActivityDescription
        {
            IEnumerable<(int transition, bool isActive)> GetTransitions();
        }

        public abstract class BaseTransitionActivityDescription : ITransitionActivityDescription
        {
            public IEnumerable<(int transition, bool isActive)> GetTransitions()
            {
                var fields = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

                var transitionsData = new List<(int, bool)>();

                foreach (var fieldInfo in fields)
                {
                    if (fieldInfo.GetCustomAttribute(typeof(TransitionAttribute)) is TransitionAttribute attribute)
                    {
                        transitionsData.Add((attribute.Transition, (bool)fieldInfo.GetValue(this)));
                    }
                }

                return transitionsData;
            }
        }

        public virtual IEnumerable<TTransitionType> GetActiveTransitions()
        {
            var descriptions = GetDescriptions();

            if (descriptions == null)
            {
                yield break;
            }

            foreach (var description in descriptions)
            {
                var transitions = description.GetTransitions();

                foreach (var (transition, isActive) in transitions)
                {
                    if (isActive)
                    {
                        yield return ConvertFromInt(transition);
                    }
                }
            }
        }

        protected IEnumerable<ITransitionActivityDescription> GetDescriptions()
        {
            foreach (var fieldInfo in GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (fieldInfo.GetCustomAttribute(typeof(SerializeField)) is SerializeField)
                {
                    yield return (ITransitionActivityDescription)fieldInfo.GetValue(this);
                }
            }
        }

        protected abstract TTransitionType ConvertFromInt(int value);
    }
}