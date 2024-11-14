using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public class MoveCharacterState : BaseCharacterState
    {
        public override CharacterState State => CharacterState.Move;

        protected override async UniTask HandleControl()
        {
            await base.HandleControl();

            ApplyMove(Config.MaxSpeed);
        }
    }
}