using System;
using System.Numerics;
using PondLibrary.Utils;

namespace PondLibrary.Entities
{
    public class Entity
    {
        public Vector2 Location { get; private set; }
        public float Radius { get; private set; }

        public const float DefaultRadius = 1F;

        // Unique indentifier, will be used for saving on disk
        public Guid Guid { get; } = Guid.NewGuid();

        public Entity(Vector2 location, float radius = DefaultRadius)
        {
            Location = location;
            Radius = radius;
        }

        public Entity(float x, float y) : this(new Vector2(x, y))
        {
        }

        public Entity() : this(Pond.RandomPoint())
        {
        }

        public override string ToString()
        {
            return $"Entity: x = {Location.X,6:###0.00}; y = {Location.Y,6:###0.00}; " +
                   $"GUID = {Guid}";
        }

        public bool IsColliding(Entity entity)
        {
            return Vector2.Distance(Location, entity.Location) < Radius + entity.Radius;
        }
    }
}
