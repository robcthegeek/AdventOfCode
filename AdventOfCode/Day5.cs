using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    // Day 5: Sunny with a Chance of Asteroids
    public class Day5
    {
        private static class OpCode
        {
            internal const int End = 99;

            internal static readonly Dictionary<int, Func<OpCodeParams, int>> Actions = new Dictionary<int, Func<OpCodeParams, int>>()
            {
                { 1, p =>
                    {
                        var augend = p.GetValueRelativeToPosition(1);
                        var addend = p.GetValueRelativeToPosition(2);
                        p.SetValueRelativeToPosition(3,augend + addend);
                        return p.CurrentPosition + 4;
                    }
                },
                { 2, p =>
                    {
                        var multiplicand = p.GetValueRelativeToPosition(1);
                        var multiplier = p.GetValueRelativeToPosition(2);
                        p.SetValueRelativeToPosition(3, multiplicand * multiplier);
                        return p.CurrentPosition + 4;
                    }
                },
                { 3, p =>
                    {
                        var value = p.Program[p.CurrentPosition + 1];
                        p.Program[value] = value;
                        return p.CurrentPosition + 2;
                    }
                },
                { 4, p =>
                    {
                        var value = p.GetValueRelativeToPosition(1);
                        p.Output.Add(value.ToString());
                        return p.CurrentPosition + 2;
                    }
                },
            };
        }

        private class OpCodeParams
        {
            public int CurrentPosition { get; set; }
            public int[] Program { get; set; }
            public List<string> Output { get; set; }
            
            internal int GetValueRelativeToPosition(int relative) => Program[Program[CurrentPosition + relative]];
            internal int SetValueRelativeToPosition(int relative, int value) => Program[Program[CurrentPosition + relative]] = value;

        }

        public static int[] Parse(string input) => input
                .Split(',')
                .Select(int.Parse)
                .ToArray();

        public static int[] Execute(string input, List<string> output = null) => Execute(Parse(input), output);

        public static int[] Execute(int[] program, List<string> output = null)
        {
            var position = 0;
            var @out = output ?? new List<string>();

            while (program[position] != OpCode.End)
            {
                if (OpCode.Actions.ContainsKey(program[position]))
                {
                    var @params = new OpCodeParams
                    {
                        CurrentPosition = position,
                        Program = program,
                        Output = @out
                    };

                    position = OpCode.Actions[program[position]](@params);
                }
            }

            return program;
        }
    }
}
