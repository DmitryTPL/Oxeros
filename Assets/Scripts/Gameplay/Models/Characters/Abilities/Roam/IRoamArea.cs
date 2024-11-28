﻿using UnityEngine;

namespace Gameplay
{
    public interface IRoamArea
    {
        public float MinRoamPathLength { get; }

        void Init(Collider area, float minRoamPathLength);
        bool IsInside(Vector3 position);
        Vector3 GetPointInside();
    }
}