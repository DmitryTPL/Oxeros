using StateMachine;

namespace Gameplay
{
    public interface IMobTransition : ITransition<MobState, MobTransition>
    {
    }
}