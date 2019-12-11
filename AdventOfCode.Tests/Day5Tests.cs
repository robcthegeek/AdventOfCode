using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day5Tests
    {
        [Fact]
        public void parse_creates_array_of_positions()
        {
            var input = "99";
            Assert.Equal(99, Day5.Parse(input)[0]);
        }

        [Fact]
        public void opcode_1_adds_values()
        {
            var input = "1,0,0,0,99"; // => "2,0,0,0,99" (1 + 1 = 2)
            Assert.Equal(new[] { 2, 0, 0, 0, 99 }, Day5.Execute(input));
        }

        [Fact]
        public void opcode_2_multiplies_values_then_halts()
        {
            var input = "2,3,0,3,99"; // => "2,3,0,6,99" (3 * 2 = 6)
            Assert.Equal(new[] { 2, 3, 0, 6, 99 }, Day5.Execute(input));
        }

        [Fact]
        public void opcode_3_takes_input_value_then_halts()
        {
            var program = "3,2,0,99"; // => "3,2,99,99"
            var input = new Queue<int>(new [] { 99 });
            Assert.Equal(new[] { 3, 2, 99, 99 }, Day5.Execute(program, input));
        }

        [Fact]
        public void opcode_4_outputs_value_then_halts()
        {
            var program = "4,0,99"; // => outputs '4' from address 0
            var output = new List<int>();
            Day5.Execute(program, null, output);
            Assert.Contains(4, output);
        }

        [Theory]
        [InlineData("2,3,0,3,99", 2, 3, 0, 6, 99)] // => 2,3,0,6,99 (3 * 2 = 6)
        [InlineData("2,4,4,5,99,0", 2, 4, 4, 5, 99, 9801)] // => 2,4,4,5,99,9801 (99 * 99 = 9801).
        public void returns_expected_from_samples(string input, params int[] expected)
        {
            Assert.Equal(expected, Day5.Execute(input));
        }

        [Theory]
        [InlineData("1002,4,3,4,33", 1002, 4, 3, 4, 99)] // => 2,3,0,6,99 (33 * 3 = 99)
        public void handles_immediate_mode(string input, params int[] expected)
        {
            Assert.Equal(expected, Day5.Execute(input));
        }

        [Fact]
        public void can_solve_puzzle()
        {
            var program = Day5.Parse(Input.Day(5));

            var input = new Queue<int>(new[] { 1 });
            var output = new List<int>();
            
            var result = Day5.Execute(program, input, output);

            output.ForEach(Console.WriteLine);
            Assert.Equal(9938601, output.Last());
        }
    }
}
