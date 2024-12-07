using System;
using AdventOfCode.ApiService.Day1;

namespace AdventOfCode.ApiService.Tests.Day1;

public class Day1SolverTests
{
    [Fact]
    public void PartOne()
    {
        var input = File.ReadAllText("Day1/input.txt");
        var safeCount = new Day1Solver().CalculatePartOne(input);
        Assert.Equal(2066446, safeCount);
    }

    [Fact]
    public void PartTwo()
    {
        var input = File.ReadAllText("Day1/input.txt");
        var safeCount = new Day1Solver().CalculatePartTwo(input);
        Assert.Equal(42140160, safeCount);
    }
}
