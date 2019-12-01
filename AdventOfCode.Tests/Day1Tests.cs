using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day1Tests
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void fuelrequired_returns_expected_for_given_mass(int mass, int expected)
        {
            var actual = Day1.FuelRequired(mass);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void can_solve_part_one()
        {
            var result = Input.Lines(1, 1)
                .Select(x => Day1.FuelRequired(int.Parse(x)))
                .Sum();
            
            Console.WriteLine(result);

            Assert.True(result > 0);
        }
    }

    public static class Input
    {
        public static string Day(int dayNumber, int partNumber) =>
            File.ReadAllText($"Input\\Day{dayNumber}.{partNumber}.txt");

        public static IEnumerable<string> Lines(int dayNumber, int partNumber) =>
            Day(dayNumber, partNumber).Split(Environment.NewLine);
    }
}
