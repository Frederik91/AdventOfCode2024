using System.Text.RegularExpressions;
using AdventOfCode.ApiService.Day3;
using AdventOfCode.ApiService.Day3.Sequences;

namespace AdventOfCode.ApiService.Tests.Day3;

public class UnitTests
{
    [Theory]
    [InlineData("mul(4,2)", 8)]
    [InlineData("mul(42,2)", 84)]
    [InlineData("mul(4,2)mul(2,3)", 14)]
    [InlineData("why()mul(164,591)", 96924)]
    [InlineData("dsamul(4,2)dsamul(2,3)", 14)]
    [InlineData("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))", 161)]
    public void SamplesPart1(string input, int? expected)
    {
        var result = Parser.Parse(input);
        if (expected is null)
        {
            Assert.Empty(result);
            return;
        }
        var actual = result.Sum();
        Assert.Equal(expected.Value, actual);
    }

    [Theory]
    [InlineData("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))", 48)]
    [InlineData("mul(2,4)don't()mul(5,5)do()mul(8,5)", 48)]
    public void SamplesPart2(string input, int? expected)
    {
        var result = Parser.Parse(input, includeDisable: true);
        if (expected is null)
        {
            Assert.Empty(result);
            return;
        }
        var actual = result.Sum();
        Assert.Equal(expected.Value, actual);
    }

    [Theory]
    [InlineData("1,", 1, true, 1)]
    [InlineData("12,", 2, true, 12)]
    [InlineData("123,", 3, true, 123)]
    [InlineData("1234,", 4, false, 0)]
    public void NumberSequenceTests(string input, int expectedSkipLength, bool expectedIsValid, int expectedNumber)
    {
        var cut = new NumberSequence();
        var isValid = cut.IsValid(input.AsSpan(), out var skipLength);

        Assert.Equal(expectedSkipLength, skipLength);
        Assert.Equal(expectedIsValid, isValid);
        Assert.Equal(expectedNumber, cut.Number);
    }

    [Theory]
    [InlineData("dont", false)]
    [InlineData("don't()", true)]
    public void IsDisableFlag(string input, bool expected)
    {
        var actual = Parser.IsDisableFlag(input.AsSpan());
        Assert.Equal(expected, actual);
    }
}
