using System;
using System.Numerics;
using PondLibrary.Utils;
using PondLibrary.Vendor;

namespace PondLibrary.Entities
{
    public class Strider : Entity
    {
        // Скорость измеряем в см/с, поле размером 1000х1000 см
        public const float MaxSpeedAmount = 2F;

        // Поворот не более чем на Х градусов в сек
        public readonly float MaxTurnAmount = VMath.DegToRad(15F);

        public Vector2 Velocity { get; private set; } = Vector2.One;

        public float Speed
        {
            get => Velocity.Length();
            set => Velocity =
                Velocity.Resized(value.Clamped(0.0F, MaxSpeedAmount));
        }

        public float Angle
        {
            get => Velocity.Angle();
            set => Velocity = Velocity.Rotated(value);
        }

        public Strider(Vector2 location, Vector2 velocity,
            float radius = DefaultRadius)
            : base(location, radius)
        {
            Speed = velocity.Length();
            Angle = velocity.Angle();
        }

        public Strider(float x, float y, float speed, float angle,
            float radius = DefaultRadius) : base(x, y, radius)
        {
            Speed = speed;
            Angle = angle;
        }

        public Strider(float x, float y, float radius = DefaultRadius) : base(x,
            y, radius)
        {
            SetRandomVelocity();
        }

        public Strider(float radius = DefaultRadius) : base(radius)
        {
            SetRandomVelocity();
        }

        public override string ToString()
        {
            return
                $"Strider: x = {X,6:###0.00}; y =   {Y,6:###0.00};\n" +
                $"         v = {Speed,6:###0.00}; phi = {Angle,6:###0.00};\n" +
                $"         GUID = {Guid.ToString().Substring(0,4)}";
        }

        private void SetRandomVelocity()
        {
            float speed = Rand.Rand1D.NextFloat(0F, MaxSpeedAmount);
            float angle = Rand.Rand1D.NextFloat(0F, 2F * VMath.PI);

            Velocity = VMath.FromPolar(speed, angle);
        }

        // Установить новую скорость как долю от максимальной скорости
        public void SetSpeedUnited(float unit)
        {
            Speed += unit * MaxSpeedAmount;
        }

        // Поворот на долю от максимального угла, 
        // < 0.5 - поворот против часовой, > 0.5 - по часовой
        public void TurnUnited(float unit)
        {
            Angle += (unit * 2 - 1) * MaxTurnAmount;
        }

        public override void Tick()
        {
            Location = Pond.ClampBounds(Location + Velocity);
        }
    }
}
