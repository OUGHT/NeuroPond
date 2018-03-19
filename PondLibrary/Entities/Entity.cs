using System;
using System.Numerics;
using PondLibrary.Utils;

namespace PondLibrary.Entities
{
    public class Entity
    {
        public Vector2 Location { get; private set; }

        // Unique indentifier, will be used for saving on disk
        public Guid Guid { get; } = Guid.NewGuid();

        public Entity(Vector2 location)
        {
            Location = location;
        }

        public Entity(float x, float y) : this(new Vector2(x, y))
        {
        }

        public Entity() : this(Rand.RandomPondPoint())
        {
        }

        public override string ToString()
        {
            return $"Entity: x = {Location.X,6:###0.00}; y = {Location.Y,6:###0.00}; GUID = {Guid}";
        }
    }
}
