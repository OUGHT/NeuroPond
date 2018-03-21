using System;
using System.Numerics;

namespace PondLibrary.Utils
{
    public class VMath
    {
        public const float PI = (float) Math.PI;

        public static Vector2 FromPolar(float r, float phi)
        {
            return new Vector2(
                r * (float) Math.Cos(phi),
                r * (float) Math.Sin(phi)
            );
        }

        public static float DegToRad(float phi)
        {
            return phi * PI / 180F;
        }

        public static float RadToDeg(float phi)
        {
            return phi * 180F / PI;
        }
    }
}
