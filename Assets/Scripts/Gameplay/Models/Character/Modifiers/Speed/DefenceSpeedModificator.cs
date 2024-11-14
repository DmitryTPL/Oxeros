using System;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Gameplay
{
    public class DefenceSpeedModificator : ISpeedModificator, IFixedTickable
    {
        public const float DefaultValue = 1f;

        private readonly ICharacterPersistentData _persistentData;
        private readonly float _activeValue;

        public AsyncReactiveProperty<float> Value { get; } = new(1f);


        public DefenceSpeedModificator(ICharacterPersistentData persistentData, CharacterConfig config)
        {
            _persistentData = persistentData;

            _activeValue = config.SpeedModifications[SpeedModification.Defence];
        }

        public void FixedTick()
        {
            if (_persistentData.IsDefending)
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