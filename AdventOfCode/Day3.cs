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

        private readonly HashSet<Coord> _wired = new HashSet<Coord>
        {
            new Coord(0, 0)
        };

        private readonly HashSet<Coord> _crossed = new HashSet<Coord>();

        public int DistanceToClosestIntersection =>
            _crossed
                .Select(x => Manhattan.Distance(new Coord(0, 0), x))
                .OrderBy(x => x)
                .First();

        public void Lay(string wire)
        {
            var path = wire.Split(',');
            var loc = new Coord(0,0);

            var current = new HashSet<Coord>();
            void Track(Coord coord)
            {
                if (!current.Contains(coord) && _wired.Contains(loc))
                    _crossed.Add(loc);

                _wired.Add(coord);
                current.Add(coord);
            }
            
            foreach (var leg in path)
            {
                var instr = Parser.Match(leg);
                for (var i = 0; i < int.Parse(instr.Groups["len"].Value); i++)
                {
                    loc = loc.Shift(instr.Groups["dir"].Value);
                    Track(loc);
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
                case "U": return new Coord(X, Y-1);
                case "D": return new Coord(X, Y+1);
                case "L": return new Coord(X-1, Y);
                case "R": return new Coord(X+1, Y);
                default: throw new ArgumentException("Unexpected Direction");
            }
        }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    internal static class Manhattan
    {
        public static int Distance(Coord a, Coord b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }
}
