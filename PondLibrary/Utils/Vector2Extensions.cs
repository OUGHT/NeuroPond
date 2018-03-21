using System;
using System.Numerics;

namespace PondLibrary.Utils
{
    public static class Vector2Extensions
    {
        public static float Angle(this Vector2 v)
        {
            return (float) Math.Atan2(v.Y, v.X);
        }

        public static (float, float) ToPolar(this Vector2 v)
        {
            float r = v.Length();
            float phi = Angle(v);
            return (r, phi);
        }

        public static Vector2 Resized(this Vector2 v, float r)
        {
            return Vector2.Normalize(v) * r;
        }

        public static Vector2 Rotated(this Vector2 v, float phi)
        {
            return Vector2.Transform(v, Matrix3x2.CreateRotation(phi));
        }
    }
}
