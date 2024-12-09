using System;
using AdventOfCode.ApiService.Day7;

namespace AdventOfCode.ApiService.Tests.Day7;

public class Day7SolverTests
{
    [Fact]
    public void PartOne_Example()
    {
        var input =
"""
190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20
""";

        var result = new Day7Solver().CalculatePartOne(input);
        
        Assert.Equal(3749, result);
    }

    [Fact]
    public void PartOne()
    {
        var input = File.ReadAllText("Day7/input.txt");

        var result = new Day7Solver().CalculatePartOne(input);
        
        Assert.Equal(303876485655, result);
    }

    [Fact]
    public void PartTwo_Example()
    {
        var input =
"""
190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20
""";

        var result = new Day7Solver().CalculatePartTwo(input);
        
        Assert.Equal(11387, result);
    }

    [Fact]
    public void PartTwo()
    {
        var input = File.ReadAllText("Day7/input.txt");

        var result = new Day7Solver().CalculatePartTwo(input);
        
        Assert.True(result > 303876485655);
        Assert.Equal(0, result);
    }
}
