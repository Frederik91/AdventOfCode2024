using System;
using AdventOfCode.ApiService.Day7;

namespace AdventOfCode.ApiService.Tests.Day7;

public class EquationsParserTests
{
    [Fact]
    public void Parse()
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
        var equations = EquationsParser.Parse(input);

        Assert.Equal(9, equations.Count);
        Assert.Equal(190, equations[0].ExpectedValue);
        Assert.Equal([10, 19], equations[0].Values);
    }
}