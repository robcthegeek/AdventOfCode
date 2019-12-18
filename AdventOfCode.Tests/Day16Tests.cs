using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day16Tests
    {
        [Theory]
        [InlineData("12345678", "48226158", "34040438", "03415518", "01029498")]
        public void sample_is_working(string input, params string[] phases)
        {
            var fft = new Day16.FFT(input);

            for (int i = 0; i < phases.Length; i++)
            {
                var result = fft.Phase();
                Assert.Equal(phases[i], result);
            }
        }
    }
}
