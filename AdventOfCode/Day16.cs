using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    // Day 16: Flawed Frequency Transmission
    public class Day16
    {
        public class FFT
        {
            private int[] _current;
            private int[] _next;

            public FFT(string input)
            {
                var ints = input.Select(x => x - 48); //.ToArray();

                _next = new int[ints.Count()];

                for (int i = 0; i < ints.Count(); i++)
                {

                }
            }

            public string Phase()
            {
                return string.Empty;
            }
        }
    }
}
