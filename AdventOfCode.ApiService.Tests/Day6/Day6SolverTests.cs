using System;
using AdventOfCode.ApiService.Day6;

namespace AdventOfCode.ApiService.Tests.Day6;

public class Day6SolverTests
{
    [Fact]
    public void PartOne_Example() {
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
        Assert.Equal(5955, safeCount);
    }

    [Fact]
    public void PartTwo()
    {
        var input = File.ReadAllText("Day6/input.txt");
        var safeCount = new Day6Solver().CalculatePartTwo(input);
        Assert.Equal(4030, safeCount);
    }
}
