using System;
using PondLibrary;

namespace PondConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pond = new Pond(5);

            foreach(var item in pond.Food)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
