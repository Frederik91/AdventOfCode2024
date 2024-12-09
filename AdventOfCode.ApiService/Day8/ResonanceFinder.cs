using System;

namespace AdventOfCode.ApiService.Day8;

public class ResonanceFinder(Map map)
{
    public List<Point2d> GetResonancePoints(AntennaLines lines)
    {
        var resonancePoints = new HashSet<Point2d>();

        foreach (var line in lines.GetLines())
        {
            var resonancePointsInLine = GetResonancePointsInLine(line);
            foreach (var point in resonancePointsInLine)
            {
                resonancePoints.Add(point);
            }
        }

        return [.. resonancePoints];
    }

    private List<Point2d> GetResonancePointsInLine(AntennaLine line)
    {
        if (line.Start.X == line.End.X)
        {
            return GetResonancePointsInVerticalLine(line);
        }

        if (line.Start.Y == line.End.Y)
        {
            return GetResonancePointsInHorizontalLine(line);
        }

        if (line.Start.X < line.End.X)
        {
            return GetResonancePointsInDiagonalLineTopLeftToBottomRight(line);
        }

        return GetResonancePointsInDiagonalLineBottomLeftToTopRight(line);
    }

    public List<Point2d> GetResonancePointsInVerticalLine(AntennaLine line)
    {
        var start = Math.Min(line.Start.Y, line.End.Y);
        var end = Math.Max(line.Start.Y, line.End.Y);
        var distance = end - start;

        var result = new List<Point2d>(2);

        var topResonance = end - (distance * 2);
        if (topResonance >= 0)
        {
            var topPoint = new Point2d(line.Start.X, topResonance);
            result.Add(topPoint);
        }
        var bottomResonance = start + (distance * 2);
        if (bottomResonance < map.Height)
        {
            var bottomPoint = new Point2d(line.Start.X, bottomResonance);
            result.Add(bottomPoint);
        }

        return result;
    }

    public List<Point2d> GetResonancePointsInHorizontalLine(AntennaLine line)
    {
        var start = Math.Min(line.Start.X, line.End.X);
        var end = Math.Max(line.Start.X, line.End.X);
        var distance = end - start;

        var result = new List<Point2d>(2);

        var leftResonance = end - (distance * 2);
        if (leftResonance >= 0)
        {
            var leftPoint = new Point2d(leftResonance, line.Start.Y);
            result.Add(leftPoint);
        }
        var rightResonance = start + (distance * 2);
        if (rightResonance < map.Width)
        {
            var rightPoint = new Point2d(rightResonance, line.Start.Y);
            result.Add(rightPoint);
        }

        return result;
    }

    public List<Point2d> GetResonancePointsInDiagonalLineTopLeftToBottomRight(AntennaLine line)
    {
        var xDistance = line.End.X - line.Start.X;
        var minX = line.Start.X;

        var minResonanceX = minX - xDistance;

        var yDistance = line.End.Y - line.Start.Y;
        var minY = line.Start.Y;

        var minResonanceY = minY - yDistance;

        var result = new List<Point2d>(2);

        if (minResonanceX >= 0 && minResonanceY >= 0)
        {
            var point = new Point2d(minResonanceX, minResonanceY);
            result.Add(point);
        }

        var maxResonanceX = minX + (xDistance * 2);
        var maxResonanceY = minY + (yDistance * 2);

        if (maxResonanceX < map.Width && maxResonanceY < map.Height)
        {
            var point = new Point2d(maxResonanceX, maxResonanceY);
            result.Add(point);
        }

        return result;

    }

    public List<Point2d> GetResonancePointsInDiagonalLineBottomLeftToTopRight(AntennaLine line)
    {
        var xDistance = line.Start.X - line.End.X;
        var minX = line.End.X;

        var minResonanceX = minX - xDistance ;

        var yDistance = line.End.Y - line.Start.Y;
        var minY = line.Start.Y;

        var minResonanceY = minY - yDistance;

        var result = new List<Point2d>(2);

        if (minResonanceX >= 0 && minResonanceY >= 0)
        {
            var point = new Point2d(minResonanceX, minResonanceY);
            result.Add(point);
        }

        var maxResonanceX = minX + (xDistance * 2);
        var maxResonanceY = minY + (yDistance * 2);

        if (maxResonanceX < map.Width && maxResonanceY < map.Height)
        {
            var point = new Point2d(maxResonanceX, maxResonanceY);
            result.Add(point);
        }

        return result;
    }
}
