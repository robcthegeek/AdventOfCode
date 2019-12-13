using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day8Tests
    {
        [Fact]
        public void can_create_sample_sif_image()
        {
            var sif = new Day8.SifImage(3, 2, "123456789012");
            Assert.Equal(2, sif.Layers.Count);
            Assert.Equal("789012", sif.LayerWithFewest(0));
        }

        [Fact]
        public void can_solve_part_1()
        {
            var sif = new Day8.SifImage(25, 6, Input.Day(8));
            var layer = sif.LayerWithFewest(0);
            var num1 = layer.Count(c => c == 1.DigitToChar());
            var num2 = layer.Count(c => c == 2.DigitToChar());
            var ans = num1 * num2;
            Console.WriteLine($"Count '1' ({num1}) * Count '2' ({num2}) = {ans}");
            Assert.Equal(1905, ans);
        }
    }
}
