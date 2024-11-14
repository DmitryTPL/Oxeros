using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;

namespace Gameplay
{
    public interface IModifiersHolder
    {
        float TotalValue { get; }
    }

    public abstract class ModifiersHolder : IModifiersHolder
    {
        private readonly IEnumerable<IModificator> _modifiers;

        public float TotalValue { get; private set; } = 1;

        protected ModifiersHolder(IEnumerable<IModificator> modifiers, CancellationToken token)
        {
            _modifiers = modifiers;

            foreach (var modificator in modifiers)
            {
                modificator.Value.WithoutCurrent().ForEachAsync(ModificatorValueChanged, token).Forget();
            }
        }

        private void ModificatorValueChanged(float value)
        {
            TotalValue = 1;

            foreach (var modificator in _modifiers)
            {
                TotalValue *= modificator.Value;
            }
        }
    }
}