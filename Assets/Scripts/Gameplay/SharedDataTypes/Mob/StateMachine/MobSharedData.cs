using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public class MobSharedData : IMobSharedData
    {
        public AsyncReactiveProperty<MobState> CurrentState { get; set; } = new(default);
    }
}