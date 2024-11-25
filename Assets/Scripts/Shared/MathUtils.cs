﻿using UnityEngine;

namespace Shared
{
    public static class MathUtils
    {
        public static float GetInterpolant(float sharpness, float deltaTime)
        {
            return Mathf.Clamp01(1f - Mathf.Exp(-sharpness * deltaTime));
        }

        public static Quaternion GetShortestRotation(Quaternion a, Quaternion b)
        {
            return Quaternion.Dot(a, b) < 0
                ? a * Quaternion.Inverse(Multiply(b, -1))
                : a * Quaternion.Inverse(b);
        }

        public static Quaternion Multiply(Quaternion quaternion, float scalar)
        {
            return new Quaternion(quaternion.x * scalar, quaternion.y * scalar, quaternion.z * scalar, quaternion.w * scalar);
        }
    }
}