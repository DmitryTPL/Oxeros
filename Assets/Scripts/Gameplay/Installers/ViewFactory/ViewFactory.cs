using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class ViewFactory : IViewFactory
    {
        private readonly DiContainer _container;

        public ViewFactory(DiContainer container)
        {
            _container = container;
        }

        public GameObject Create(GameObject prefab)
        {
            var gameObject = Object.Instantiate(prefab);
            
            var gameObjectContext = gameObject.GetComponent<GameObjectContext>();
            
            gameObjectContext.Construct(_container);

            return gameObject;
        }
    }
}