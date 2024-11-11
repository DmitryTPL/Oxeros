﻿using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public interface IGravityForceReaction
    {
        AsyncReactiveProperty<Vector3> GravityForce { get; }
    }

    public class GravityForceReaction : IGravityForceReaction
    {
        public AsyncReactiveProperty<Vector3> GravityForce { get; } = new(default);
    }
}