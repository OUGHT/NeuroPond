using System;
using System.Collections.Generic;
using System.Linq;
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

        public event EventHandler OnCollide;

        // Unique indentifier, will be used for saving on disk
        public Guid Guid { get; } = Guid.NewGuid();
        public string GuidReadable => Guid.ToString().Substring(0, 4);

        protected List<Entity> collisionHandled = new List<Entity>();
        protected Pond pond;

        public Entity(Pond pond, Vector2 location, float radius = DefaultRadius)
        {
            this.pond = pond;
            Location = location;
            Radius = radius;
        }

        public Entity(Pond pond, float x, float y, float radius = DefaultRadius) : this(pond,
            new Vector2(x, y), radius)
        {
        }

        public Entity(Pond pond, float radius = DefaultRadius) : this(pond, pond.RandomPoint(),
            radius)
        {
        }

        public void Move(float x, float y)
        {
            Location = new Vector2(x, y);
        }

        public override string ToString()
        {
            return $"Entity: x = {X,6:###0.00}; y = {Y,6:###0.00}; " +
                   $"        GUID = {GuidReadable}";
        }

        public virtual void Tick()
        {
            HandleCollisions();
        }

        public bool IsCollidingWith(Entity entity)
        {
            return Vector2.Distance(Location, entity.Location) < Radius + entity.Radius;
        }

        public void HandleCollisions()
        {
            collisionHandled.Clear();
            // Проходим через LINQ по всем объектам. 
            // TODO: Неэффективно, в будущем надо оптимизировать
            var collidingEntities = from entity in pond.Entities
                where entity.IsCollidingWith(this)
                select entity;
            foreach (Entity collidingEntity in collidingEntities)
            {
                HandleCollision(collidingEntity);
                collidingEntity.HandleCollision(this);
            }
        }

        public void HandleCollision(Entity entity)
        {
            if (collisionHandled.Contains(entity)) return;
            CollideWith(entity);
            collisionHandled.Add(entity);
        }

        // Поведение при столкновении
        public void CollideWith(Entity entity)
        {
            // Оповестить всех, кто хочет знать, шо мы врезались
            // TODO: Переделать, чтобы им отправлялась, кроме нас, еще и цель
            OnCollide?.Invoke(this, EventArgs.Empty);
        }
    }
}
