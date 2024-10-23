using System;
using Data;
using Unity.Collections.LowLevel.Unsafe;
using Zenject;

namespace StateMachine
{
    public interface IStateTimingHandler<in TTimingState>
        where TTimingState : Enum
    {
        void SetTiming(TTimingState timing, float duration);
        void RemoveTiming(TTimingState timing);
        bool IsTimePassed(TTimingState timing);
    }

    public abstract class BaseStateTimingHandler<TTimingState> : IStateTimingHandler<TTimingState>
        where TTimingState : Enum
    {
        private IAppTime _appTime;
        private readonly float[] _timings;

        protected BaseStateTimingHandler()
        {
            _timings = new float[Enum.GetValues(typeof(TTimingState)).Length];
        }

        [Inject]
        public void AddDependencies(IAppTime appTime)
        {
            _appTime = appTime;
        }

        public void SetTiming(TTimingState timing, float duration)
        {
            var index = UnsafeUtility.As<TTimingState, int>(ref timing);

            _timings[index] = _appTime.Time + duration;
        }

        public void RemoveTiming(TTimingState timing)
        {
            var index = UnsafeUtility.As<TTimingState, int>(ref timing);

            _timings[index] = 0;
        }

        public bool IsTimePassed(TTimingState timing)
        {
            var index = UnsafeUtility.As<TTimingState, int>(ref timing);

            return _appTime.Time >= _timings[index];
        }
    }
}