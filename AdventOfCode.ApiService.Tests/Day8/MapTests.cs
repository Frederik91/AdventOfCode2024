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

        Assert.Equal(3, lines.Count());
    }

    [Fact]
        public void GetLines_HorizontalLines_AllValidLinesAreIdentified()
        {
            // Arrange: A horizontal line of antennas
            var antennas = new List<Antenna>
            {
                new(new Point2d(0, 1), 'a'),
                new(new Point2d(1, 1), 'a'),
                new(new Point2d(2, 1), 'a')
            };
            var map = new Map(antennas, 3, 3);

            // Act
            var lines = map.GetLines();

            // Assert: Verify all valid horizontal lines are detected
            Assert.Contains(new AntennaLine(new Point2d(0, 1), new Point2d(1, 1), 'a'), lines);
            Assert.Contains(new AntennaLine(new Point2d(1, 1), new Point2d(2, 1), 'a'), lines);
        }

        [Fact]
        public void GetLines_VerticalLines_AllValidLinesAreIdentified()
        {
            // Arrange: A vertical line of antennas
            var antennas = new List<Antenna>
            {
                new(new Point2d(1, 0), 'a'),
                new(new Point2d(1, 1), 'a'),
                new(new Point2d(1, 2), 'a')
            };
            var map = new Map(antennas, 3, 3);

            // Act
            var lines = map.GetLines();

            // Assert: Verify all valid vertical lines are detected
            Assert.Contains(new AntennaLine(new Point2d(1, 0), new Point2d(1, 1), 'a'), lines);
            Assert.Contains(new AntennaLine(new Point2d(1, 1), new Point2d(1, 2), 'a'), lines);
        }

        [Fact]
        public void GetLines_DiagonalTopLeftToBottomRight_AllValidLinesAreIdentified()
        {
            // Arrange: A diagonal line from top-left to bottom-right
            var antennas = new List<Antenna>
            {
                new(new Point2d(0, 0), 'a'),
                new(new Point2d(1, 1), 'a'),
                new(new Point2d(2, 2), 'a')
            };
            var map = new Map(antennas, 3, 3);

            // Act
            var lines = map.GetLines();

            // Assert: Verify all valid diagonal lines are detected
            Assert.Contains(new AntennaLine(new Point2d(0, 0), new Point2d(1, 1), 'a'), lines);
            Assert.Contains(new AntennaLine(new Point2d(1, 1), new Point2d(2, 2), 'a'), lines);
        }

        [Fact]
        public void GetLines_DiagonalTopRightToBottomLeft_AllValidLinesAreIdentified()
        {
            // Arrange: A diagonal line from top-right to bottom-left
            var antennas = new List<Antenna>
            {
                new(new Point2d(2, 0), 'a'),
                new(new Point2d(1, 1), 'a'),
                new(new Point2d(0, 2), 'a')
            };
            var map = new Map(antennas, 3, 3);

            // Act
            var lines = map.GetLines();

            // Assert: Verify all valid diagonal lines are detected
            Assert.Contains(new AntennaLine(new Point2d(2, 0), new Point2d(1, 1), 'a'), lines);
            Assert.Contains(new AntennaLine(new Point2d(1, 1), new Point2d(0, 2), 'a'), lines);
        }

        [Fact]
        public void GetLines_NoLinesFound_WhenAntennasAreIsolated()
        {
            // Arrange: Isolated antennas with no valid lines
            var antennas = new List<Antenna>
            {
                new(new Point2d(0, 0), 'a'),
                new(new Point2d(2, 2), 'b')
            };
            var map = new Map(antennas, 3, 3);

            // Act
            var lines = map.GetLines();

            // Assert: Verify no lines are detected
            Assert.Empty(lines);
        }

        [Fact]
        public void GetLines_HandlesMixedAntennaTypes()
        {
            // Arrange: Mixed antenna types in the grid
            var antennas = new List<Antenna>
            {
                new(new Point2d(0, 0), 'a'),
                new(new Point2d(1, 1), 'b'),
                new(new Point2d(2, 2), 'a')
            };
            var map = new Map(antennas, 3, 3);

            // Act
            var lines = map.GetLines();

            // Assert: Verify only valid lines of matching types are detected
            Assert.Contains(new AntennaLine(new Point2d(0, 0), new Point2d(2, 2), 'a'), lines);
            Assert.DoesNotContain(new AntennaLine(new Point2d(0, 0), new Point2d(1, 1), 'a'), lines);
        }
}
