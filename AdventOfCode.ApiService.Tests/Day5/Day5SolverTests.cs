using System;
using AdventOfCode.ApiService.Day5;

namespace AdventOfCode.ApiService.Tests.Day5;

public class Day5SolverTests
{
    [Fact]
    public void PartOne()
    {
        var input = File.ReadAllText("Day5/input.txt");
        var safeCount = new Day5Solver().CalculatePartOne(input);
        Assert.Equal(5955, safeCount);
    }

    [Fact]
    public void PartTwo()
    {
        var input = File.ReadAllText("Day5/input.txt");
        var safeCount = new Day5Solver().CalculatePartTwo(input);
        Assert.Equal(4030, safeCount);
    }

}
