using System;
using AdventOfCode.ApiService.Day6;

namespace AdventOfCode.ApiService.Tests.Day6;

public class Day6SolverTests
{
    [Fact]
    public void PartOne_Example()
    {
        var input =
"""
....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...
""";
        var safeCount = new Day6Solver().CalculatePartOne(input);
        Assert.Equal(41, safeCount);
    }

    [Fact]
    public void PartOne()
    {
        var input = File.ReadAllText("Day6/input.txt");
        var safeCount = new Day6Solver().CalculatePartOne(input);
        Assert.Equal(5312, safeCount);
    }

    [Fact]
    public void ThrowsInfiniteLoopException()
    {
        var input =
"""
....#.....
.........#
..........
..#.......
.......#..
..........
.#.#^.....
........#.
#.........
......#...
""";
        var solver = new Day6Solver();
        Assert.Throws<InfiniteLoopException>(() => solver.CalculatePartOne(input));
    }
    [Fact]
    public void PartTwo_Example()
    {
        var input =
"""
....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...
""";
        var loopCount = new Day6Solver().CalculatePartTwo(input);
        Assert.Equal(6, loopCount);
    }

    [Fact]
    public void PartTwo()
    {
        var input = File.ReadAllText("Day6/input.txt");
        var loopCount = new Day6Solver().CalculatePartTwo(input);
        Assert.Equal(1748, loopCount);
    }
}
