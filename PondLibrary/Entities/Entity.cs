using System;
using System.Numerics;

namespace PondLibrary.Entities
{
    public class Entity
    {
        public Vector2 Location { get; protected set; }
        public float X => Location.X;
        public float Y => Location.Y;
        public float Radius { get; protected set; }

        public const float DefaultRadius = 1F;

        // Unique indentifier, will be used for saving on disk
        public Guid Guid { get; } = Guid.NewGuid();

        public Entity(Vector2 location, float radius = DefaultRadius)
        {
            Location = location;
            Radius = radius;
        }

        public Entity(float x, float y, float radius = DefaultRadius) : this(
            new Vector2(x, y), radius)
        {
        }

        public Entity(float radius = DefaultRadius) : this(Pond.RandomPoint(),
            radius)
        {
        }

        public override string ToString()
        {
            return $"Entity: x = {X,6:###0.00}; y = {Y,6:###0.00}; " +
                   $"        GUID = {Guid.ToString().Substring(0, 4)}";
        }

        public bool IsColliding(Entity entity)
        {
            return Vector2.Distance(Location, entity.Location) < Radius + entity.Radius;
        }

        public virtual void Tick()
        {
        }
    }
}
