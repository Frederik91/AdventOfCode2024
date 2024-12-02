
using Xunit;

namespace Day2.Tests;

public class PartOneTests
{
    [Fact]
    public void TestRun()
    {
        var safeCount = PartOne.Run();
        Assert.Equal(670, safeCount);
    }

    [Theory]
    [InlineData("69 70 71 72 75")]
    [InlineData("68 69 70 71 72")]
    public void ValidLines(string line)
    {
        var result = PartOne.IsValid(line);
        Assert.True(result);
    }

    [Theory]
    [InlineData("77 80 81 84 85 86 86 90")]
    [InlineData("24 24 27 29 29 30 31 28")]
    public void InvalidLines(string line)
    {
        var result = PartOne.IsValid(line);
        Assert.False(result);
    }
}