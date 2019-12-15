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
            private readonly char[,] _image;

            private static class Color
            {
                internal const int Black = 0;
                internal const int White = 1;
                internal const int Transparent = 2;
            }

            public List<string> Layers { get; } = new List<string>();

            public string LayerWithFewest(int digit) => LayerWithFewest(digit.ToChar());

            private string LayerWithFewest(char @char) =>
                Layers
                    .OrderBy(l => l.Count(c => c == @char))
                    .First(l => l.Contains(@char));

            public SifImage(int width, int height, string digits)
            {
                _image = new char[width, height];

                var chars = new Queue<char>(digits);
                var layer = new StringBuilder();
                var z = 0;
                while (chars.Count > 0)
                {
                    for (var y = 0; y < height; y++)
                    {
                        for (var x = 0; x < width; x++)
                        {
                            if (z == 0) _image[x, y] = Color.Transparent.ToChar();

                            var c = chars.Dequeue();
                            layer.Append(c);

                            if (_image[x, y] == Color.Transparent.ToChar() && (c == '0' || c == '1'))
                            {
                                _image[x, y] = c.ToDigit() == Color.Black ? '█' : '░';
                            }
                        }
                    }

                    z++;
                    Layers.Add(layer.ToString());
                    layer.Clear();
                }
            }

            public string Render()
            {
                var sb = new StringBuilder();
                for (var y = 0; y < _image.GetLength(1); y++)
                {
                    for (var x = 0; x < _image.GetLength(0); x++)
                    {
                        sb.Append(_image[x, y]);
                    }

                    sb.AppendLine();
                }

                return sb.ToString().Trim();
            }
        }
    }

    public static class Extensions
    {
        public static char ToChar(this int digit) => Convert.ToChar(digit + 48);
        public static int ToDigit(this char @char) => Convert.ToInt32(@char - 48);
    }
}
