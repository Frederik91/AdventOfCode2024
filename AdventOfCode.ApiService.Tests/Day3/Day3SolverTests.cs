using System;
using AdventOfCode.ApiService.Day3;

namespace AdventOfCode.ApiService.Tests.Day3;

public class Day3SolverTests
{
    [Fact]
    public void PartOne()
    {
        var input = File.ReadAllText("Day3/input.txt");
        var sum = new Day3Solver().CalculatePartOne(input);
        Assert.Equal(173785482, sum);
    }

    [Fact]
    public void PartTwo()
    {
        var input = File.ReadAllText("Day3/input.txt");
        var sum = new Day3Solver().CalculatePartTwo(input);
        Assert.Equal(83158140, sum);
    }

}
