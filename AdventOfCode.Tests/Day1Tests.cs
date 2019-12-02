using System;
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
            var result = Input
                .Ints(1)
                .Select(Day1.FuelRequired)
                .Sum();
            
            Console.WriteLine(result);

            Assert.True(result > 0);
            Assert.Equal(3481005, result);
        }

        [Theory]
        [InlineData(14, 2)]
        [InlineData(1969, 966)]
        public void totalfuelrequired_returns_expected_for_given_mass(int mass, int expected)
        {
            var actual = Day1.TotalFuelRequired(mass);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void can_solve_part_two()
        {
            var result = Input.Ints(1)
                .Select(Day1.TotalFuelRequired)
                .Sum();

            Console.WriteLine(result);

            Assert.True(result > 0);
            Assert.Equal(5218616, result);
        }
    }
}
