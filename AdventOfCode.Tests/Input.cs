using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Tests
{
    internal static class Input
    {
        public static string Day(int dayNumber, int partNumber) =>
            File.ReadAllText($"Input\\Day{dayNumber}.{partNumber}.txt");

        public static IEnumerable<string> Lines(int dayNumber, int partNumber) =>
            Day(dayNumber, partNumber).Split(Environment.NewLine);

        public static IEnumerable<int> Ints(int dayNumber, int partNumber) =>
            Day(dayNumber, partNumber).Split(Environment.NewLine).Select(int.Parse);
    }
}