using System.Diagnostics.Contracts;
using System.Numerics;

namespace PondLibrary.Utils
{
    public struct Rect
    {
        public Vector2 TopLeft { get; }
        public Vector2 BottomRight { get; }

        public float Left => TopLeft.X;
        public float Top => TopLeft.Y;
        public float Right => BottomRight.X;
        public float Bottom => BottomRight.Y;

        public float Width => BottomRight.X - TopLeft.X;
        public float Height => BottomRight.Y - TopLeft.Y;

        public Rect(Vector2 topLeft, Vector2 bottomRight)
        {
            TopLeft = Vector2.Min(topLeft, bottomRight);
            BottomRight = Vector2.Max(topLeft, bottomRight);
        }

        public Rect(float left, float top, float right, float bottom) :
            this(new Vector2(left, top), new Vector2(right, bottom))
        {
        }

        [Pure]
        public Vector2 ClampHard(Vector2 point)
        {
            return Vector2.Clamp(point, TopLeft, BottomRight);
        }

        [Pure]
        public Vector2 ClampCycle(Vector2 point)
        {
            return new Vector2(
                (point.X - Left) % Width + Left,
                (point.Y - Top) % Height + Top
            );
        }

        [Pure]
        public bool IsPointInside(Vector2 point)
        {
            return ClampHard(point) == point;
        }

        [Pure]
        public override string ToString()
        {
            return
                $"Rect: Left  = {Left,7:###0.00}; Top    = {Top,7:###0.00};\n" +
                $"      Right = {Right,7:###0.00}; Bottom = {Bottom,7:###0.00};";
        }
    }
}
