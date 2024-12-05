using System;

namespace Day4;

public class CrossMasFinderTests
{
    [Fact]
    public void PartTwo()
    {
        var input = File.ReadAllText("input.txt");
        var result = CrossMasFinder.Count(input);

        Assert.Equal(1916, result);
    }

    [Fact]
    public void Example()
    {
        var input =
"""
.M.S......
..A..MSMS.
.M.S.MAA..
..A.ASMSM.
.M.S.M....
..........
S.S.S.S.S.
.A.A.A.A..
M.M.M.M.M.
..........
""";

        var result = CrossMasFinder.Count(input);

        Assert.Equal(9, result);
    }
}
