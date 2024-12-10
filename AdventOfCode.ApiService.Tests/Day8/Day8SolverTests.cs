using System;
using AdventOfCode.ApiService.Day8;

namespace AdventOfCode.ApiService.Tests.Day8;

public class Day8SolverTests
{
    [Fact]
    public void CalculatePartOne_ShouldReturnExpectedResult()
    {
        // Arrange
        var input = File.ReadAllText("Day8/input.txt");
        var solver = new Day8Solver();

        // Act
        var result = solver.CalculatePartOne(input);

        // Assert
        Assert.Equal(249, result);
    }

    [Fact]
    public void CalculatePartTwo_ShouldReturnExpectedResult()
    {
        // Arrange
        var input = File.ReadAllText("Day8/input.txt");
        var solver = new Day8Solver();

        // Act
        var result = solver.CalculatePartTwo(input);

        // Assert
        Assert.True(result < 1131);
        Assert.Equal(0, result);
    }
}
