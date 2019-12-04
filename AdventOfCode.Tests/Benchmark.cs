using System;
using System.Diagnostics;
using Xunit;

namespace AdventOfCode.Tests
{
    public static class Benchmark
    {
        public static void Run<T>(Func<T> a, Func<T> b)
        {
            (T result, long ticks) Time(string method, Func<T> f)
            {
                var sw = Stopwatch.StartNew();
                var result = f();
                sw.Stop();
                Console.WriteLine($"Method {method} returned {result} in {sw.ElapsedTicks} ticks.");
                return (result, sw.ElapsedTicks);
            }

            var resA = Time("A", a);
            var resB = Time("B", b);

            Console.WriteLine($"Method {((resA.ticks < resB.ticks) ? "A" : "B" )} wins!");
            var max = Math.Max(resA.ticks, resB.ticks);
            var min = Math.Min(resA.ticks, resB.ticks);
            var inc = Math.Round((max - min) / (float)min * 100, 2);
            Console.WriteLine($"{inc}%");
            Assert.Equal(resA.result, resB.result);
        }
    }
}
