using StateMachine;

namespace Gameplay
{
    public interface IMobTransitionsHolder : ITransitionsHolder<MobState, MobTransition, IMobTransition>
    {
    }
}