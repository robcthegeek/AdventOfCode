using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    // Day 6: Universal Orbit Map
    public class Day6
    {
        public class Map
        {
            public int Checksum
            {
                get
                {
                    var sum = 0;

                    foreach (var kvp in _orbits)
                    {
                        sum++;
                        var next = kvp.Value;
                        while (_orbits.ContainsKey(next))
                        {
                            sum++;
                            next = _orbits[next];
                        }
                    }

                    return sum;
                }
            }

            public int TransfersRequired(string a, string b)
            {
                var san = Route("SAN", "COM");
                var you = Route("YOU", "COM");
                var intersect = san.Intersect(you).ToHashSet();
                return san.Count + you.Count - (2 * intersect.Count);
            }

            private HashSet<string> Route(string from, string to)
            {
                var result = new HashSet<string>();

                var next = _orbits[from];
                while (next != to)
                {
                    result.Add(next);
                    next = _orbits[next];
                }

                return result;
            }

            private readonly Dictionary<string, string> _orbits;

            public Map(string input)
            {
                _orbits = new Dictionary<string, string>(input.Split('\n').Select(Parse));
            }

            private KeyValuePair<string, string> Parse(string line)
            {
                return new KeyValuePair<string, string>(line.Split(')')[1].Trim(), line.Split(')')[0]);
            }
        }
    }
}
