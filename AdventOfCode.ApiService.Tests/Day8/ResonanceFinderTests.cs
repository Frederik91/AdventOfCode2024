using System;
using AdventOfCode.ApiService.Day8;
using Xunit;

namespace AdventOfCode.ApiService.Tests.Day8;

public class ResonanceFinderTests
{
    [Fact]
    public void GetResonancePoints()
    {
        var input =
"""
......#....#
...#....0...
....#0....#.
..#....0....
....0....#..
.#....A.....
...#........
#......#....
........A...
.........A..
..........#.
..........#.
""";

        var expectedLocations = GetHashCodeLocations(input);
        input = input.Replace("#", ".");
        var map = MapParser.Parse(input);
        var lines = map.GetLines();
        var resonancePoints = new ResonanceFinder(map).GetResonancePoints(lines);

        foreach (var location in resonancePoints)
        {
            Assert.Contains(location, expectedLocations);
        }

        Assert.Equal(expectedLocations.Count, resonancePoints.Count);
    }

    private static List<Point2d> GetHashCodeLocations(string input)
    {
        var locations = new List<Point2d>();
        var lines = input.Split(Environment.NewLine);
        for (var y = 0; y < lines.Length; y++)
        {
            for (var x = 0; x < lines[y].Length; x++)
            {
                if (lines[y][x] == '#')
                {
                    locations.Add(new Point2d(x, y));
                }
            }
        }

        return locations;
    }

    [Fact]
    public void GetResonancePointsInVerticalLine()
    {
        var map = new Map([], 10, 10);
        var line = new AntennaLine(new Point2d(2, 2), new Point2d(2, 4), AntennaType.Lowercase);
        var resonancePoints = new ResonanceFinder(map).GetResonancePointsInVerticalLine(line);

        Assert.Contains(new Point2d(2, 0), resonancePoints);
        Assert.Contains(new Point2d(2, 6), resonancePoints);
    }

    [Fact]
    public void GetResonancePointsInHorizontalLine()
    {
        var map = new Map([], 10, 10);
        var line = new AntennaLine(new Point2d(2, 2), new Point2d(4, 2), AntennaType.Lowercase);
        var resonancePoints = new ResonanceFinder(map).GetResonancePointsInHorizontalLine(line);

        Assert.Contains(new Point2d(0, 2), resonancePoints);
        Assert.Contains(new Point2d(6, 2), resonancePoints);
    }

    [Fact]
    public void GetResonancePointsInDiagonalLineTopLeftToBottomRight()
    {
        var map = new Map([], 10, 10);
        var line = new AntennaLine(new Point2d(4, 4), new Point2d(6, 6), AntennaType.Lowercase);
        var resonancePoints = new ResonanceFinder(map).GetResonancePointsInDiagonalLineTopLeftToBottomRight(line);

        Assert.Contains(new Point2d(2, 2), resonancePoints);
        Assert.Contains(new Point2d(8, 8), resonancePoints);
    }

    [Fact]
    public void GetResonancePointsInDiagonalLineBottomLeftToTopRight()
    {
        var map = new Map([], 10, 10);
        var line = new AntennaLine(new Point2d(6, 4), new Point2d(4, 6), AntennaType.Lowercase);
        var resonancePoints = new ResonanceFinder(map).GetResonancePointsInDiagonalLineBottomLeftToTopRight(line);

        Assert.Contains(new Point2d(2, 2), resonancePoints);
        Assert.Contains(new Point2d(8, 8), resonancePoints);
    }
}
