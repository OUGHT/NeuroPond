using System;
using System.Collections.Generic;
using System.Linq;

namespace PondLibrary
{
    public class Pond
    {
        private const double XMin = 0.0;
        private const double YMin = 0.0;
        private const double XMax = 1000.0;
        private const double YMax = 1000.0;

        public Random Rand { get; set; } = new Random();

        private List<int> foodEntities;
        public List<int> FoodEntities => foodEntities;

        public Pond()
        {
        }

        public Pond(int foodAmount)
        {
            foodEntities = Enumerable.Range(1, foodAmount)
                                     .Select(x => Rand.Next()).ToList();
        }


    }
}
