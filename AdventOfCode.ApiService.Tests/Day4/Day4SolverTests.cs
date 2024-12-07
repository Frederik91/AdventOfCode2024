using System;
using AdventOfCode.ApiService.Day4;

namespace AdventOfCode.ApiService.Tests.Day4;

public class Day4SolverTests
{
    [Fact]
    public void PartOne()
    {
        var input = File.ReadAllText("Day4/input.txt");
        var safeCount = new Day4Solver().CalculatePartOne(input);
        Assert.Equal(2554, safeCount);
    }

    [Fact]
    public void PartTwo()
    {
        var input = File.ReadAllText("Day4/input.txt");
        var safeCount = new Day4Solver().CalculatePartTwo(input);
        Assert.Equal(1916, safeCount);
    }
}
