using AdventOfCode.ApiService.Day4;

namespace AdventOfCode.ApiService.Tests.Day4;

public class CrossMasFinderTests
{
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
