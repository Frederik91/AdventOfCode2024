using System;
using AdventOfCode.ApiService.Day7;

namespace AdventOfCode.ApiService.Tests.Day7;

public class EquationTests
{
    [Theory]
    [InlineData(2, new int[] { 1, 1 }, true)]
    [InlineData(2, new int[] { 1, 1, 1 }, true)]
    [InlineData(2, new int[] { 1, 1, 1, 1 }, true)]
    [InlineData(5, new int[] { 2, 2}, false)]
    public void EvaluateCanBeSolved(int expectedValue, int[] values, bool expected)
    {
        var equation = new Equation(expectedValue, values);
        var canBeSolved = equation.EvaluateCanBeSolved();
        Assert.Equal(expected, canBeSolved);
    }
}
