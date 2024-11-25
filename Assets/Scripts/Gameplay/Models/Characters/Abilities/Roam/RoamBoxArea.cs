﻿using UnityEngine;

namespace Gameplay
{
    public interface IRoamArea
    {
        public float MinRoamPathLength { get; }

        void Init(Collider areaCollider, float minRoamPathLength);
        bool IsInside(Vector3 position);
        Vector3 GetPointInside();
    }

    public interface IRoamBoxArea : IRoamArea
    {
    }

    public class RoamBoxArea : IRoamBoxArea
    {
        private BoxCollider _area;

        public float MinRoamPathLength { get; private set; }

        public void Init(Collider area, float minRoamPathLength)
        {
            _area = (BoxCollider)area;
            MinRoamPathLength = minRoamPathLength;
        }

        public bool IsInside(Vector3 position)
        {
            return _area.bounds.Contains(position);
        }

        public Vector3 GetPointInside()
        {
            var bounds = _area.bounds;

            var point = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );

            if (point != _area.ClosestPoint(point))
            {
                Debug.Log("Out of the collider! Looking for other point...");
                point = GetPointInside();
            }

            return point;
        }
    }
}