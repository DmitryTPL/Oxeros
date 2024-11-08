using Zenject;

namespace Gameplay
{
    public class MoveInputPresenter : BaseInputPresenter
    {
        public MoveInputPresenter()
            : base(null)
        {
        }

        [Inject]
        public MoveInputPresenter(IMoveInputData inputData)
            : base(inputData)
        {
        }
    }
}