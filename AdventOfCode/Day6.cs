using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    // Day 6: Universal Orbit Map
    public class Day6
    {
        public class Map
        {
            public int Checksum { get; private set; }

            public Map(string input)
            {
                var orbits = input.Split('\n').Select(Parse).ToList();
                var level = new HashSet<string>() { "COM" };
                var depth = 0;
                var sum = 0;

                while (level.Count > 0)
                {
                    depth++;
                    level = orbits
                        .Where(orbit => level.Contains(orbit.orbited))
                        .Select(orbit => orbit.orbiter)
                        .ToHashSet();
                    sum += depth * level.Count();
                }

                Checksum = sum;
            }

            private (string orbited, string orbiter) Parse(string line)
            {
                var split = line.Split(')');
                return (split[0], split[1].Trim());
            }
        }
    }
}
