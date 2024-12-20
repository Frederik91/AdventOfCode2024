using System;
using AdventOfCode.ApiService.Day6;

namespace AdventOfCode.ApiService.Tests.Day6;

public class MapParserTests
{
    [Fact]
    public void ParseMap()
    {
        var input =
"""
..........
.#..^.....
........#.
""";
        var expected = new int[][]
        {
            [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            [0, 1, 0, 0, 0, 0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0, 0, 0, 0, 1, 0]
        };

        var map = MapParser.Parse(input);

        Assert.Equal(expected, map.Obstacles);
    }

    [Fact]
    public void ParseMap_LocateGuard()
    {
        var input =
"""
....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...
""";

        var expected = new Point2d(4, 6);

        var map = MapParser.Parse(input);
        
        Assert.Equal(expected, map.IntialPosition);
    }
}