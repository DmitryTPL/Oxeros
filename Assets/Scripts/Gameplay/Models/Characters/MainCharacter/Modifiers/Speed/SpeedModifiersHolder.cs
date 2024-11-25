using System.Collections.Generic;
using System.Threading;

namespace Gameplay
{
    public interface ISpeedModifiersHolder : IModifiersHolder
    {
    }

    public class SpeedModifiersHolder : ModifiersHolder, ISpeedModifiersHolder
    {
        public SpeedModifiersHolder(IList<ISpeedModificator> modifiers, CancellationToken token)
            : base(modifiers, token)
        {
        }
    }
}