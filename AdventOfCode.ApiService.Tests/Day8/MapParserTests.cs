using System;
using AdventOfCode.ApiService.Day8;

namespace AdventOfCode.ApiService.Tests.Day8;

public class MapParserTests
{
    [Fact]
    public void ParseMap()
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

        Assert.Equal(3, map.Antennas.Count);

        var antenna = map.Antennas[0].Values.First();
        Assert.Equal(4, antenna.Location.X);
        Assert.Equal(3, antenna.Location.Y);
        Assert.Equal(10, map.Height);
        Assert.Equal(10, map.Height);
    }
}
