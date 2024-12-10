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

        var antannasOfType = Assert.Single(map.Antennas);
        Assert.Equal(3, antannasOfType.Value.Count);

        var antenna = map.Antennas[antannasOfType.Key].Values.First();
        Assert.Equal(4, antenna.Location.X);
        Assert.Equal(3, antenna.Location.Y);
        Assert.Equal(10, map.Height);
        Assert.Equal(10, map.Height);
    }
}
