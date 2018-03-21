using System.Collections.Generic;
using System.Numerics;
using PondLibrary.Entities;
using PondLibrary.Utils;

namespace PondLibrary
{
    public class Pond
    {
        public const float XMin = 0.0F;
        public const float YMin = 0.0F;
        public const float XMax = 1000.0F;
        public const float YMax = 1000.0F;
        public readonly Rect Bounds = new Rect(XMin, YMin, XMax, YMax);

        public const int TickLength = 20; // Длительность тика в мс

        public List<Entity> Entities { get; } = new List<Entity>();

        public Pond()
        {
        }

        public Pond(int foodAmount)
        {
            for (int i = 0; i < foodAmount; i++)
            {
                AddFood();
            }
        }

        public Vector2 RandomPoint()
        {
            return new Vector2(
                Rand.Rand2D.NextFloat(XMin, XMax),
                Rand.Rand2D.NextFloat(YMin, YMax)
            );
        }

        public Vector2 ClampBounds(Vector2 v)
        {
            return Bounds.ClampCycle(v);
        }

        public Entity AddFood()
        {
            var entity = new Entity(this);
            Entities.Add(entity);
            return entity;
        }

        public Strider AddStrider()
        {
            var strider = new Strider(this);
            Entities.Add(strider);
            return strider;
        }

        public void Tick()
        {
            foreach (Entity entity in Entities)
            {
                entity.Tick();
            }
        }
    }
}
