using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day4Tests
    {
        [Theory]
        [InlineData(12345, false)]  // not six digits
        [InlineData(113456, true)]
        [InlineData(111111, true)]  // double 11, never decreases
        [InlineData(223450, false)] // decreasing pair of digits 50
        [InlineData(123789, false)] // no double
        public void passcode_validate_correctly(int passcode, bool expected)
        {
            Assert.Equal(expected, Passcode.IsValid(passcode));
        }

        [Fact]
        public void can_solve_part_1()
        {
            var answer = Passcode.ValidInRange(372037, 905157);
            Console.WriteLine(answer);
            Assert.Equal(481, answer);
        }
    }
}
