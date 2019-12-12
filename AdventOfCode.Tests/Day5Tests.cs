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

        [Theory]
        [InlineData("3,9,8,9,10,9,4,9,99,-1,8", 8, 1)]  // pos mode, equal
        [InlineData("3,9,8,9,10,9,4,9,99,-1,8", 9, 0)]  // pos mode, equal
        [InlineData("3,3,1108,-1,8,3,4,3,99", 8, 1)]    // immediate mode, equal
        [InlineData("3,3,1108,-1,8,3,4,3,99", 9, 0)]    // immediate mode, equal
        [InlineData("3,9,7,9,10,9,4,9,99,-1,8", 8, 0)]  // pos mode, less than
        [InlineData("3,9,7,9,10,9,4,9,99,-1,9", 8, 1)]  // pos mode, less than
        [InlineData("3,3,1107,-1,8,3,4,3,99", 8, 0)]    // immediate mode, less than
        [InlineData("3,3,1107,-1,9,3,4,3,99", 8, 1)]    // immediate mode, less than
        public void handles_comparison_samples(string program, int input, int expOutput)
        {
            var output = new List<int>();

            Day5.Execute(program, new Queue<int>(new[] { input }), output);

            Assert.Equal(expOutput, output.Last());
        }

        [Theory]
        [InlineData("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", 0, 0)]  // position mode
        [InlineData("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", 42, 1)] // position mode
        [InlineData("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", 0, 0)]       // immediate mode
        [InlineData("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", 42, 1)]      // immediate mode
        public void handles_jump_to_samples(string program, int input, int expOutput)
        {
            var output = new List<int>();

            Day5.Execute(program, new Queue<int>(new[] { input }), output);

            Assert.Equal(expOutput, output.Last());
        }

        [Theory]
        [InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104,999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99", 7, 999)]
        [InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104,999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99", 8, 1000)]
        [InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104,999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99", 9, 1001)]
        public void handles_larger_sample(string program, int input, int expOutput)
        {
            var output = new List<int>();

            Day5.Execute(program, new Queue<int>(new[] { input }), output);

            Assert.Equal(expOutput, output.Last());
        }

        [Fact]
        public void can_solve_part_1()
        {
            var program = Day5.Parse(Input.Day(5));

            var input = new Queue<int>(new[] { 1 });
            var output = new List<int>();

            var result = Day5.Execute(program, input, output);

            output.ForEach(Console.WriteLine);
            Assert.Equal(9938601, output.Last());
        }

        [Fact]
        public void can_solve_part_2()
        {
            var program = Day5.Parse(Input.Day(5));

            var input = new Queue<int>(new[] { 5 });
            var output = new List<int>();

            var result = Day5.Execute(program, input, output);

            output.ForEach(Console.WriteLine);
            Assert.Equal(4283952, output.Last());
        }
    }
}
