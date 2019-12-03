using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day3Tests
    {
        [Fact]
        public void can_solve_first_sample()
        {
            var grid = new Grid();
            grid.Lay("R8,U5,L5,D3");
            grid.Lay("U7,R6,D4,L4");
            Assert.Equal(6, grid.DistanceToClosestIntersection);
        }

        [Fact]
        public void can_solve_second_sample()
        {
            var grid = new Grid();
            grid.Lay("R75,D30,R83,U83,L12,D49,R71,U7,L72");
            grid.Lay("U62,R66,U55,R34,D71,R55,D58,R83");
            Assert.Equal(159, grid.DistanceToClosestIntersection);
        }

        [Fact]
        public void can_solve_third_sample()
        {
            var grid = new Grid();
            grid.Lay("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51");
            grid.Lay("U98,R91,D20,R16,D67,R40,U7,R15,U6,R7");
            Assert.Equal(135, grid.DistanceToClosestIntersection);
        }

        [Fact]
        public void can_solve_puzzle()
        {
            var grid = new Grid();
            Input.Lines(3).ToList().ForEach(grid.Lay);
            var answer = grid.DistanceToClosestIntersection;
            Console.WriteLine(answer);
            Assert.Equal(2050, answer);
        }

        [Fact]
        public void can_get_quickest_intersection()
        {
            var grid = new Grid();
            grid.Lay("R8,U5,L5,D3");
            grid.Lay("U7,R6,D4,L4");
            Assert.Equal(30, grid.LengthToQuickestIntersection);
        }

        [Fact]
        public void part_2_sample_1()
        {
            var grid = new Grid();
            grid.Lay("R75,D30,R83,U83,L12,D49,R71,U7,L72");
            grid.Lay("U62,R66,U55,R34,D71,R55,D58,R83");
            Assert.Equal(610, grid.LengthToQuickestIntersection);
        }

        [Fact]
        public void part_2_sample_2()
        {
            var grid = new Grid();
            grid.Lay("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51");
            grid.Lay("U98,R91,D20,R16,D67,R40,U7,R15,U6,R7");
            Assert.Equal(410, grid.LengthToQuickestIntersection);
        }

        [Fact]
        public void can_solve_part_2()
        {
            var grid = new Grid();
            Input.Lines(3).ToList().ForEach(grid.Lay);
            var answer = grid.LengthToQuickestIntersection;
            Console.WriteLine(answer);
            Assert.Equal(21666, answer);
        }
    }
}
