using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    // Day 8: Space Image Format
    public class Day8
    {
        public class SifImage
        {
            public List<string> Layers { get; } = new List<string>();

            public string LayerWithFewest(int digit) => LayerWithFewest(digit.DigitToChar());
            
            private string LayerWithFewest(char @char) =>
                Layers
                    .OrderBy(l => l.Count(c => c == @char))
                    .First(l => l.Contains(@char));

            public SifImage(int width, int height, string digits)
            {
                var chars = new Queue<char>(digits);
                var layer = new StringBuilder();

                while (chars.Count > 0)
                {
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            layer.Append(chars.Dequeue());
                        }
                    }

                    Layers.Add(layer.ToString());
                    layer.Clear();
                }
            }
        }
    }

    public static class Extensions
    {
        public static char DigitToChar(this int digit) => Convert.ToChar(digit + 48);
    }
}
