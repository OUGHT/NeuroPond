using System.Numerics;

namespace PondLibrary.Entities
{
    // TODO: Implement food
    public class Food : Entity
    {
        public Food(Pond pond, Vector2 location, float radius = DefaultRadius) : base(pond, location, radius)
        {
        }

        public Food(Pond pond, float x, float y, float radius = DefaultRadius) : base(pond, x, y, radius)
        {
        }

        public Food(Pond pond, float radius = DefaultRadius) : base(pond, radius)
        {
        }
    }
}
