using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    // Day 3: Crossed Wires
    public class Grid
    {
        private static readonly Regex Parser = new Regex("(?<dir>[UDLR])(?<len>\\d+)", RegexOptions.Compiled);

        private readonly Dictionary<Coord, int> _wired = new Dictionary<Coord, int>();

        private readonly Dictionary<Coord, int> _crossed = new Dictionary<Coord, int>();

        public int DistanceToClosestIntersection => _crossed
                .Select(x => Manhattan.Distance(new Coord(0, 0), x.Key))
                .OrderBy(x => x)
                .First();

        public int LengthToQuickestIntersection { get; private set; } = -1;

        public void Lay(string wire)
        {
            var path = wire.Split(',');
            var loc = new Coord(0, 0);
            int distance = 0;

            var current = new HashSet<Coord>();
            void Track(Coord coord, int distance)
            {
                if (!current.Contains(coord) && _wired.ContainsKey(loc))
                {
                    var otherWireDistance = _wired[loc];
                    int totalDistance = distance + otherWireDistance;
                    _crossed[loc] = totalDistance;

                    if (LengthToQuickestIntersection == -1 || totalDistance < LengthToQuickestIntersection)
                        LengthToQuickestIntersection = totalDistance;
                }
                _wired[coord] = distance;
                current.Add(coord);
            }

            foreach (var leg in path)
            {
                var instr = Parser.Match(leg);
                for (var i = 0; i < int.Parse(instr.Groups["len"].Value); i++)
                {
                    distance++;
                    loc = loc.Shift(instr.Groups["dir"].Value);
                    Track(loc, distance);
                }
            }
        }
    }

    [DebuggerDisplay("{X},{Y}")]
    internal struct Coord
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coord Shift(string dir)
        {
            switch (dir)
            {
                case "U": return new Coord(X, Y - 1);
                case "D": return new Coord(X, Y + 1);
                case "L": return new Coord(X - 1, Y);
                case "R": return new Coord(X + 1, Y);
                default: throw new ArgumentException("Unexpected Direction");
            }
        }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"{X},{Y}";
    }

    internal static class Manhattan
    {
        public static int Distance(Coord a, Coord b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }
}
