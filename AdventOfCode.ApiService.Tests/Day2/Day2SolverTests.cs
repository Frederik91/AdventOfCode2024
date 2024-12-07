using System;
using AdventOfCode.ApiService.Day2;

namespace AdventOfCode.ApiService.Tests.Day2;

public class Day2SolverTests
{
    [Fact]
    public void PartOne()
    {
        var input = File.ReadAllText("Day2/input.txt");
        var safeCount = new Day2Solver().CalculatePartOne(input);
        Assert.Equal(670, safeCount);
    }

    [Fact]
    public void PartTwo()
    {
        var input = File.ReadAllText("Day2/input.txt");
        var safeCount = new Day2Solver().CalculatePartTwo(input);
        Assert.Equal(700, safeCount);
    }

}
