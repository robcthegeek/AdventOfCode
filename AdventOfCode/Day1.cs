using System;

namespace AdventOfCode
{
    // Day 1: The Tyranny of the Rocket Equation
    public class Day1
    {
        public static int FuelRequired(int mass) => Convert.ToInt32(Math.Floor(((double)mass / 3) - 2));
        public static int TotalFuelRequired(int mass)
        {
            int result = 0;
            int additional;

            while ((additional = FuelRequired(mass)) > 0)
            {
                result += additional;
                mass = additional;
            }

            return result;
        }
    }
}
