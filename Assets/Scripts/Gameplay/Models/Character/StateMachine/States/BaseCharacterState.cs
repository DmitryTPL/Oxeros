using Cysharp.Threading.Tasks;
using Data;
using StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public abstract class BaseCharacterState : BaseStateWithTransitions<CharacterState, CharacterTransition, ICharacterTransition, ICharacterTransitionsHolder,
        ICharacterStateTimingHandler, CharacterStateTimeConfig, CharacterStateToTimeDictionary, ICharacterStateResult>, ICharacterState
    {
        private IGravityForceReaction _gravityForceReaction;

        protected CharacterConfig Config { get; private set; }
        protected ICharacterPersistentData PersistentData { get; private set; }
        protected ICharacterPerUpdateData PerUpdateData { get; private set; }
        protected IAppTime AppTime { get; private set; }

        [Inject]
        public void AddDependencies(CharacterConfig config, ICharacterPersistentData persistentData, ICharacterPerUpdateData perUpdateData,
            IAppTime appTime, IGravityForceReaction gravityForceReaction)
        {
            Config = config;
            PersistentData = persistentData;
            PerUpdateData = perUpdateData;
            AppTime = appTime;

            _gravityForceReaction = gravityForceReaction;
        }

        protected override async UniTask HandleControl()
        {
            await base.HandleControl();

            ApplyGravitationForce();
        }

        protected virtual void ApplyGravitationForce()
        {
            _gravityForceReaction.GravityForce.Value = Physics.gravity * Config.GravitationFactor;
        }

        protected Vector3 GetMoveDelta(Vector3 moveVelocity)
        {
            if (moveVelocity.magnitude < float.Epsilon)
            {
                return Vector3.zero;
            }

            PersistentData.GoalVelocity = Vector3.MoveTowards(PersistentData.GoalVelocity, moveVelocity, Config.Acceleration * AppTime.FixedDeltaTime);

            var neededAcceleration = (PersistentData.GoalVelocity - PerUpdateData.LinearVelocity) / AppTime.FixedDeltaTime;

            return Vector3.ClampMagnitude(Vector3.Scale(neededAcceleration, new Vector3(1, 0, 1)), Config.MaxAcceleration);
        }
    }
}