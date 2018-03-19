using System;
using PondLibrary;

namespace PondConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            var pond = new Pond(5);

            foreach(int item in pond.FoodEntities)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
