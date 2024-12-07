

using AdventOfCode.ApiService.Day2;

namespace AdventOfCode.ApiService.Tests.Day2;

public class PartTwoTests
{
    [Theory]
    [InlineData("71 69 70 71 72 75")]
    [InlineData("68 69 70 71 72 77")]
    public void ValidLines(string line)
    {
        var result = PartTwo.IsLineValid(line);
        Assert.True(result);
    }

    [Theory]
    [InlineData("77 80 81 84 85 86 86 90")]
    [InlineData("77 80 81 84 86 86 86 87")]
    public void InvalidLines(string line)
    {
        var result = PartTwo.IsLineValid(line);
        Assert.False(result);
    }
}