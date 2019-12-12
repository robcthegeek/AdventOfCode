using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    // Day 5: Sunny with a Chance of Asteroids
    public class Day5
    {
        internal class Add : OpCode
        {
            public Add(int code) : base(code) { }

            public override int Execute(int[] program, int currentPosition)
            {
                var augend = GetParameterValue(1, currentPosition, program);
                var addend = GetParameterValue(2, currentPosition, program);
                SetParameterValue(3, currentPosition, augend + addend, program);
                return currentPosition + 4;
            }
        }

        internal class Multiply : OpCode
        {
            public Multiply(int code) : base(code) { }

            public override int Execute(int[] program, int currentPosition)
            {
                var multiplicand = GetParameterValue(1, currentPosition, program);
                var multiplier = GetParameterValue(2, currentPosition, program);
                SetParameterValue(3, currentPosition, multiplicand * multiplier, program);
                return currentPosition + 4;
            }
        }

        internal class Input : OpCode
        {
            public Input(int code) : base(code) { }

            public override int Execute(int[] program, int currentPosition)
            {
                var value = Input.Dequeue();
                SetParameterValue(1, currentPosition, value, program);
                return currentPosition + 2;
            }
        }

        internal class Output : OpCode
        {
            public Output(int code) : base(code)
            {

            }

            public override int Execute(int[] program, int currentPosition)
            {
                var value = GetParameterValue(1, currentPosition, program);
                Output.Add(value);
                return currentPosition + 2;
            }
        }

        internal class LessThan: OpCode
        {
            public LessThan(int code) : base(code)
            {

            }

            public override int Execute(int[] program, int currentPosition)
            {
                var first = GetParameterValue(1, currentPosition, program);
                var second = GetParameterValue(2, currentPosition, program);
                var updated = SetParameterValue(3, currentPosition, (first < second ? 1 : 0), program);
                return updated == currentPosition ? program[currentPosition] : currentPosition + 4;
            }
        }

        internal class Equality : OpCode
        {
            public Equality(int code) : base(code)
            {

            }

            public override int Execute(int[] program, int currentPosition)
            {
                var first = GetParameterValue(1, currentPosition, program);
                var second = GetParameterValue(2, currentPosition, program);
                var updated = SetParameterValue(3, currentPosition, first == second ? 1 : 0, program);
                return updated == currentPosition ? program[currentPosition] : currentPosition + 4;
            }
        }

        internal class JumpIfTrue : OpCode
        {
            public JumpIfTrue(int code) : base(code)
            {

            }

            public override int Execute(int[] program, int currentPosition)
            {
                return (GetParameterValue(1, currentPosition, program) != 0)
                    ? GetParameterValue(2, currentPosition, program)
                    : currentPosition + 3;
            }
        }

        internal class JumpIfFalse : OpCode
        {
            public JumpIfFalse(int code) : base(code)
            {

            }

            public override int Execute(int[] program, int currentPosition)
            {
                return (GetParameterValue(1, currentPosition, program) == 0)
                    ? GetParameterValue(2, currentPosition, program)
                    : currentPosition + 3;
            }
        }


        public abstract class OpCode
        {
            protected Queue<int> Input;
            protected List<int> Output;

            internal const int PositionMode = 0;
            internal const int End = 99;

            public int Code { get; }
            public int[] ParamModes = new int[3];

            protected OpCode(int value)
            {
                Input ??= new Queue<int>();
                Output ??= new List<int>();

                var chars = value.ToString("D5").ToCharArray();
                Code = (int)char.GetNumericValue(chars[4]);
                ParamModes[0] = (int)char.GetNumericValue(chars[2]);
                ParamModes[1] = (int)char.GetNumericValue(chars[1]);
                ParamModes[2] = (int)char.GetNumericValue(chars[0]);
            }

            public static OpCode FromInt(int value, Queue<int> input, List<int> output)
            {
                var chars = value.ToString("D5").ToCharArray();
                var code = (int)char.GetNumericValue(chars[4]);

                OpCode op = code switch
                {
                    1 => new Add(value),
                    2 => new Multiply(value),
                    3 => new Input(value),
                    4 => new Output(value),
                    5 => new JumpIfTrue(value),
                    6 => new JumpIfFalse(value),
                    7 => new LessThan(value),
                    8 => new Equality(value),
                    _ => null,
                };

                op.Input = input ?? new Queue<int>();
                op.Output = output ?? new List<int>();

                return op;
            }

            public abstract int Execute(int[] program, int currentPosition);

            protected int GetParameterValue(int paramNum, int currentPosition, int[] program)
            {
                var mode = ParamModes[paramNum - 1];
                var index = currentPosition + paramNum;
                return mode == PositionMode ? program[program[index]] : program[index];
            }

            protected int SetParameterValue(int paramNum, int currentPosition, int value, int[] program)
            {
                var mode = ParamModes[paramNum - 1];
                var index = currentPosition + paramNum;
                var updated = mode == PositionMode
                    ? program[index]
                    : index;

                program[updated] = value;

                return updated;

            }
        }

        public static int[] Parse(string input) => input
                .Split(',')
                .Select(int.Parse)
                .ToArray();

        public static int[] Execute(string program, Queue<int> input = null, List<int> output = null) => Execute(Parse(program), input, output);

        public static int[] Execute(int[] program, Queue<int> input = null, List<int> output = null)
        {
            var position = 0;

            while (program[position] != OpCode.End)
            {
                position = OpCode.FromInt(program[position], input, output).Execute(program, position);
            }

            return program;
        }
    }
}
