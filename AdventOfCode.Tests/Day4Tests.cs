using System;
using System.Linq;
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
        public void passcode_validates_correctly(int passcode, bool expected)
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

        [Theory]
        [InlineData(112233, true)]  // digits never decrease and all repeated digits are exactly two digits long
        [InlineData(123444, false)] // the repeated 44 is part of a larger group of 444
        [InlineData(111122, true)]  // even though 1 is repeated more than twice, it still contains a double 22
        [InlineData(123456, false)]
        [InlineData(224444, true)]  // has pair, irrespective of larger group
        public void passcode_part_deux_validates_correctly(int value, bool expected)
        {
            var answer = Passcode.IsValidPartDeux(value);
            Assert.Equal(expected, answer);
        }

        [Fact]
        public void can_solve_part_2()
        {
            var answer = Passcode.ValidInRangePartDeux(372037, 905157);
            Console.WriteLine(answer);
            Assert.Equal(299, answer);
        }

        [Fact]
        public void can_count()
        {
            var answer = Count(111122);
            Assert.Equal(2, answer);
        }

        static int Count(int value)
        {
            var chars = value.ToString().ToCharArray();
            char last = chars[0];
            var count = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == last) {
                    count++;
                } else
                {
                    count = 1;
                }
                last = chars[i];
            }

            return count;
        }
    }
}
