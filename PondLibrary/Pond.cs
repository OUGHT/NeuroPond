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
        public readonly Rect Bounds = new Rect(XMin, YMax, XMax, YMin); // Тестируем корявые границы
//        public readonly Rect Bounds = new Rect(XMin, YMin, XMax, YMax);
        
        public List<Entity> Food { get; } = new List<Entity>();

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

        public void AddFood()
        {
            Food.Add(new Entity());
        }

        public static Vector2 RandomPoint()
        {
            return new Vector2(
                Rand.Rand2D.NextFloat(XMin, XMax),
                Rand.Rand2D.NextFloat(YMin, YMax)
            );
        }
    }
}
