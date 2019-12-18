using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day6Tests
    {
        [Fact]
        public void can_calc_orbits_from_sample()
        {
            var input =
                "COM)B" + Environment.NewLine +
                "B)C" + Environment.NewLine +
                "C)D" + Environment.NewLine +
                "D)E" + Environment.NewLine +
                "E)F" + Environment.NewLine +
                "B)G" + Environment.NewLine +
                "G)H" + Environment.NewLine +
                "D)I" + Environment.NewLine +
                "E)J" + Environment.NewLine +
                "J)K" + Environment.NewLine +
                "K)L";

            var map = new Day6.Map(input);

            Assert.Equal(42, map.Checksum);
        }

        [Fact]
        public void can_solve_sample_for_part_2()
        {
            var input =
                "COM)B" + Environment.NewLine +
                "B)C" + Environment.NewLine +
                "C)D" + Environment.NewLine +
                "D)E" + Environment.NewLine +
                "E)F" + Environment.NewLine +
                "B)G" + Environment.NewLine +
                "G)H" + Environment.NewLine +
                "D)I" + Environment.NewLine +
                "E)J" + Environment.NewLine +
                "J)K" + Environment.NewLine +
                "K)L" + Environment.NewLine +
                "K)YOU" + Environment.NewLine +
                "I)SAN";

            var map = new Day6.Map(input);

            Assert.Equal(4, map.TransfersRequired("YOU", "SAN"));
        }

        [Fact]
        public void can_solve_part_1()
        {
            var input = Input.Day(6);
            var map = new Day6.Map(input);
            Console.WriteLine($"{map.Checksum}");
            Assert.Equal(292387, map.Checksum);
        }

        [Fact]
        public void can_solve_part_2()
        {
            var input = Input.Day(6);
            var map = new Day6.Map(input);
            int answer = map.TransfersRequired("YOU", "SAN");
            Console.WriteLine($"{answer}");
            Assert.Equal(433, answer);
        }
    }
}
