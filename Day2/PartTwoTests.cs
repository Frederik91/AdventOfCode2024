
using Xunit;

namespace Day2.Tests;

public class PartTwoTests
{
    [Fact]
    public void EntireFile()
    {
        var safeCount = PartTwo.Run();
        Assert.Equal(700, safeCount);
    }

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