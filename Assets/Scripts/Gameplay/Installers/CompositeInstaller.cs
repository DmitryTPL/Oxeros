using System.Linq;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CompositeInstaller : MonoInstaller
    {
        [SerializeField] private MonoInstaller[] _monoInstallers;

        public override void InstallBindings()
        {
            foreach (var installer in _monoInstallers)
            {
                Container.Inject(installer);
                
                installer.InstallBindings();
            }
        }

        [ContextMenu("Collect Installers")]
        public void CollectInstallers()
        {
            _monoInstallers = gameObject.GetComponentsInChildren<MonoInstaller>(true).Where(x => x != this).ToArray();
        }
    }
}