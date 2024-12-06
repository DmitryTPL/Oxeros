using System.Collections.Generic;
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
            var installers = new HashSet<MonoInstaller>();

            GetInstallers(gameObject, installers);
            _monoInstallers = installers.ToArray();
            
            #if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(gameObject);
            #endif
        }

        private void GetInstallers(GameObject root, ISet<MonoInstaller> installers)
        {
            for (var i = 0; i < root.transform.childCount; i++)
            {
                var child = root.transform.GetChild(i);

                if (child.transform.childCount > 0 && !child.gameObject.TryGetComponent<GameObjectContext>(out _))
                {
                    GetInstallers(child.gameObject, installers);
                }

                var monoInstallers = child.gameObject.GetComponents<MonoInstaller>();

                if (monoInstallers.Length > 0)
                {
                    foreach (var installer in monoInstallers)
                    {
                        installers.Add(installer);
                    }
                }
            }
        }
    }
}