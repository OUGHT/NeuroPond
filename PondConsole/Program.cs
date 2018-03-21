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
            var pond = new Pond(2);

            Console.WriteLine(Pond.Bounds);
            Console.WriteLine();

            foreach (Entity entity in pond.Entities)
            {
                Console.WriteLine(entity);
            }

//            pond.AddStrider();
            pond.AddStrider();

            for (int i = 0; i < 5; i++)
            {
                foreach (Entity entity in pond.Entities)
                {
                    if (entity is Strider strider)
                    {
                        Console.WriteLine(strider);
                    }
                }
                Thread.Sleep(Pond.TickLength);
                pond.Tick();
            }


            Console.ReadLine();
        }
    }
}
