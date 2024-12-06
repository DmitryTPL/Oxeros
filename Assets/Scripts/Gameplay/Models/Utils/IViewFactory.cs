using UnityEngine;

namespace Gameplay
{
    public interface IViewFactory
    {
        GameObject Create(GameObject prefab);
    }
}