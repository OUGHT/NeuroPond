using System;
using System.Threading;
using PondLibrary;
using PondLibrary.Entities;

namespace PondConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pond = new Pond(200);

            Console.WriteLine(pond.Bounds);
            Console.WriteLine();

//            foreach (Entity entity in pond.Entities)
//            {
//                Console.WriteLine(entity);
//            }

            Strider strider = pond.AddStrider();
            strider.Move(50f, 50f);
            strider.SetSpeedUnited(1);
            strider.Angle = 0f;
            strider.OnCollide += (obj, e) =>
                Console.WriteLine($"Strider {strider.GuidReadable} collided!");
            Console.WriteLine(strider);

            Entity food = pond.AddFood();
            food.Move(55f, 50f);
            Console.WriteLine(food);
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                foreach (Entity entity in pond.Entities)
                {
                    if (entity is Strider value)
                    {
                        Console.WriteLine(value);
                    }
                }
//                Thread.Sleep(Pond.TickLength);
                pond.Tick();
            }
            Console.WriteLine("Finished!");

            Console.ReadLine();
        }
    }
}
