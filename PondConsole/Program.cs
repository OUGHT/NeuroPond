using System;
using PondLibrary;
using PondLibrary.Entities;

namespace PondConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pond = new Pond(5);

            Console.WriteLine(pond.Bounds);
            Console.WriteLine();

            foreach (Entity item in pond.Food)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
