using System;
using AdventOfCode.ApiService.Day8;
using Xunit;

namespace AdventOfCode.ApiService.Tests.Day8;

public class ResonanceFinderTests
{
    private readonly Map map;
    private readonly ResonanceFinder _cut;

    public ResonanceFinderTests()
    {
        // Initialize the map with specific dimensions
        map = new Map([], 100, 100);

        _cut = new ResonanceFinder(map);
    }

    [Fact]
    public void GetResonancePoints_Example2()
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

        // Add overlapping antenna location
        expectedLocations.Add(new Point2d(6, 5));
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

    [Fact]
    public void GetResonancePoints_Example1()
    {
        var input =
"""
..........
...#......
#.........
....a.....
........a.
.....a....
..#.......
......A...
..........
..........
""";

        var expectedLocations = GetHashCodeLocations(input);

        // Add overlapping antenna location
        expectedLocations.Add(new Point2d(6, 7));
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
    public void ResonancePoints_LineWithinBounds_ReturnsTwoPoints()
    {
        // Arrange
        var line = new AntennaLine(new Point2d(20, 20), new Point2d(30, 30), 'a');

        // Act
        var result = _cut.GetResonancePointsInLine(line);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(result, p => p.X == 10 && p.Y == 10);
        Assert.Contains(result, p => p.X == 40 && p.Y == 40);
    }

    [Fact]
    public void ResonancePoints_LinePartiallyOutOfBounds_ReturnsOnePoint()
    {
        // Arrange
        var line = new AntennaLine(new Point2d(85, 85), new Point2d(95, 95), 'a');

        // Act
        var result = _cut.GetResonancePointsInLine(line);

        // Assert
        Assert.Single(result);
        Assert.Contains(result, p => p.X == 75 && p.Y == 75); // Only the valid point
    }

    [Fact]
    public void ResonancePoints_OneResonancePointInvalid_ReturnsOnePoint()
    {
        // Arrange
        var line = new AntennaLine(new Point2d(90, 90), new Point2d(95, 95), 'a');

        // Act
        var result = _cut.GetResonancePointsInLine(line);

        // Assert
        Assert.Single(result);
        Assert.Contains(result, p => p.X == 85 && p.Y == 85); // Only the valid point
    }

    [Fact]
    public void ResonancePoints_LineDiagonalWithinBounds_ReturnsTwoPoints()
    {
        // Arrange
        var line = new AntennaLine(new Point2d(40, 60), new Point2d(50, 70), 'a');

        // Act
        var result = _cut.GetResonancePointsInLine(line);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(result, p => p.X == 30 && p.Y == 50);
        Assert.Contains(result, p => p.X == 60 && p.Y == 80);
    }

    [Theory]
    [InlineData(10, 10, 20, 20)] // Diagonal line (45 degrees)
    [InlineData(10, 10, 10, 20)] // Vertical line
    [InlineData(10, 10, 20, 10)] // Horizontal line
    [InlineData(10, 10, 20, 15)] // Arbitrary angle
    [InlineData(10, 10, 15, 20)] // Another arbitrary angle
    [InlineData(90, 90, 95, 95)] // Near the edge of the map
    public void ResonancePoints_InvertedLines_FindsCorrectPoints(int startX, int startY, int endX, int endY)
    {
        // Arrange
        var lineOriginal = new AntennaLine(new Point2d(startX, startY), new Point2d(endX, endY), 'a');
        var lineInverted = new AntennaLine(new Point2d(endX, endY), new Point2d(startX, startY), 'a');

        // Act
        var resultOriginal = _cut.GetResonancePointsInLine(lineOriginal);
        var resultInverted = _cut.GetResonancePointsInLine(lineInverted);

        // Calculate the expected points
        var dx = endX - startX;
        var dy = endY - startY;

        var minPoint = new Point2d(startX - dx, startY - dy);
        var maxPoint = new Point2d(endX + dx, endY + dy);

        // Validate for the original line
        ValidateResonancePoints(resultOriginal, minPoint, maxPoint);

        // Validate for the inverted line
        ValidateResonancePoints(resultInverted, minPoint, maxPoint);
    }

    private void ValidateResonancePoints(List<Point2d> result, Point2d minPoint, Point2d maxPoint)
    {
        if (IsValidPoint(minPoint))
        {
            Assert.Contains(result, p => p.X == minPoint.X && p.Y == minPoint.Y);
        }

        if (IsValidPoint(maxPoint))
        {
            Assert.Contains(result, p => p.X == maxPoint.X && p.Y == maxPoint.Y);
        }
    }

    private bool IsValidPoint(Point2d point)
    {
        return point.X >= 0 && point.X < 100 && point.Y >= 0 && point.Y < 100;
    }
}