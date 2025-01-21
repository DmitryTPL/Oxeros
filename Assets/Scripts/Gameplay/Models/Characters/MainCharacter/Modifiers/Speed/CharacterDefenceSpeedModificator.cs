using System;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Gameplay
{
    public class CharacterDefenceSpeedModificator : ISpeedModificator, IFixedTickable
    {
        public const float DefaultValue = 1f;

        private readonly IDefenceHandler _defenceHandler;
        private readonly float _activeValue;

        public AsyncReactiveProperty<float> Value { get; } = new(1f);

        public CharacterDefenceSpeedModificator(CharacterConfig config, IDefenceHandler defenceHandler)
        {
            _defenceHandler = defenceHandler;

            _activeValue = config.SpeedModifications[SpeedModification.Defence];
        }

        public void FixedTick()
        {
            if (_defenceHandler.IsDefending.Value)
            {
                if (Math.Abs(Value.Value - _activeValue) > float.Epsilon)
                {
                    Value.Value = _activeValue;
                }
            }
            else
            {
                if (Math.Abs(Value.Value - DefaultValue) > float.Epsilon)
                {
                    Value.Value = DefaultValue;
                }
            }
        }
    }
}