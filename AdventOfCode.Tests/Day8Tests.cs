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
            var num1 = layer.Count(c => c == 1.ToChar());
            var num2 = layer.Count(c => c == 2.ToChar());
            var ans = num1 * num2;
            Console.WriteLine($"Count '1' ({num1}) * Count '2' ({num2}) = {ans}");
            Assert.Equal(1905, ans);
        }

        [Fact]
        public void can_solve_part_2()
        {
            var image = new Day8.SifImage(25, 6, Input.Day(8)).Render();
            var expected =
                "█░░███░░██░██░█░░░██░░░░█" + "\r\n" +
                "░██░█░██░█░█░██░██░████░█" + "\r\n" +
                "░██░█░████░░███░██░███░██" + "\r\n" +
                "░░░░█░████░█░██░░░███░███" + "\r\n" +
                "░██░█░██░█░█░██░████░████" + "\r\n" +
                "░██░██░░██░██░█░████░░░░█";

            Console.WriteLine(image);
            Assert.Equal(expected, image);
        }

        [Theory]
        [InlineData(1, 1, "0", "█")]                       // Black
        [InlineData(1, 1, "1", "░")]                       // White
        [InlineData(2, 1, "0122", "█░")]                   // Transparent 2nd Layer
        [InlineData(2, 2, "0222112222120000", "█░\r\n░█")] // Sample Image
        public void can_render_sif_stream(int width, int height, string input, string expected)
        {
            var sif = new Day8.SifImage(width, height, input);
            var image = sif.Render();
            Console.WriteLine(image);
            Assert.Equal(expected, image);
        }
    }
}
