using Zenject;

namespace Gameplay
{
    public class AttackInputPresenter : BaseInputPresenter
    {
        public AttackInputPresenter()
            : base(null)
        {
        }

        [Inject]
        public AttackInputPresenter(IAttackInputData inputData)
            : base(inputData)
        {
        }
    }
}