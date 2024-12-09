using System;
using AdventOfCode.ApiService.Day8;

namespace AdventOfCode.ApiService.Tests.Day8;

public class MapTests
{
    [Fact]
    public void GetLines()
    {
        var input =
"""
..........
..........
..........
....a.....
........a.
.....a....
..........
..........
..........
..........
""";

        var map = MapParser.Parse(input);
        var lines = map.GetLines();

        Assert.Equal(3, lines.GetLines().Count());
    }
}
