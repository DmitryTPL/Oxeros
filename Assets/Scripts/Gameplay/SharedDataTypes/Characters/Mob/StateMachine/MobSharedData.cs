using Cysharp.Threading.Tasks;
using StateMachine;

namespace Gameplay
{
    public interface IMobSharedData : ISharedData<MobState>
    {
    }
    
    public class MobSharedData : IMobSharedData
    {
        public AsyncReactiveProperty<MobState> CurrentState { get; set; } = new(default);
    }
}