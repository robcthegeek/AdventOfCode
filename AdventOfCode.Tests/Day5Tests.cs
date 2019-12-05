using System;
using System.Collections.Generic;
using System.IO;
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
        public void opcode_3_saves_value_then_halts()
        {
            var input = "3,2,1,1,1,5,99"; // => "3,2,2,1,1,4,99" (save 2 in address 2, 2*2 from add 1 = 4, save to 5)
            Assert.Equal(new[] { 3, 2, 2, 1, 1, 4, 99 }, Day5.Execute(input));
        }

        [Fact]
        public void opcode_4_outputs_value_then_halts()
        {
            var input = "4,0,99"; // => outputs '4' from address 0
            var output = new List<string>();
            Day5.Execute(input, output);
            Assert.Contains("4", output);
        }

        [Theory]
        [InlineData("2,3,0,3,99", 2, 3, 0, 6, 99)] // => 2,3,0,6,99 (3 * 2 = 6)
        [InlineData("2,4,4,5,99,0", 2, 4, 4, 5, 99, 9801)] // => 2,4,4,5,99,9801 (99 * 99 = 9801).
        public void returns_expected_from_samples(string input, params int[] expected)
        {
            Assert.Equal(expected, Day5.Execute(input));
        }

        //[Fact]
        //public void can_solve_puzzle()
        //{
        //    var input = Day5.Parse(Input.Day(2));

        //    /* before running the program,
        //     - replace position 1 with the value 12 and
        //     - replace position 2 with the value 2. What value is left at position 0 
        //     after the program halts?
        //     */

        //    input[1] = 12;
        //    input[2] = 2;
        //    var result = Day5.Execute(input);

        //    Console.WriteLine(result[0]);
        //    Assert.Equal(3760627, result[0]);
        //}

        //[Fact]
        //public void can_solve_part2()
        //{
        //    var input = Day5.Parse(Input.Day(2));
        //    var (noun, verb) = Day5.GetNounVerbForResult(input, 19690720);
        //    var answer = 100 * noun + verb;
        //    Console.WriteLine($"100 * {noun} + {verb} = {answer}");

        //    Assert.True(noun > 0);
        //    Assert.True(verb > 0);
        //    Assert.Equal(7195, answer);
        //}
    }
}
