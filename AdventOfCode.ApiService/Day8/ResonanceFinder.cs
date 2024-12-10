using System;

namespace AdventOfCode.ApiService.Day8;

public class ResonanceFinder(Map map)
{
    public List<Point2d> GetResonanceLines(AntennaLines lines)
    {
        var resonancePoints = new HashSet<Point2d>();

        foreach (var line in lines)
        {
            var resonancePointsInLine = GetAllPointsInLine(line);
            foreach (var point in resonancePointsInLine)
            {
                resonancePoints.Add(point);
            }
        }

        return [.. resonancePoints];
    }

    private IEnumerable<Point2d> GetAllPointsInLine(AntennaLine line)
    {
        var dx = line.End.X - line.Start.X;
        var dy = line.End.Y - line.Start.Y;

        // Reduce dx and dy to the smallest possible values
        var gcd = Gcd(dx, dy);
        dx /= gcd;
        dy /= gcd;

        var result = new List<Point2d>();

        var currentX = line.Start.X;
        var currentY = line.Start.Y;

        while (IsValidX(currentX) && IsValidY(currentY))
        {
            currentX += dx;
            currentY += dy;

            var point = new Point2d(currentX, currentY);
            result.Add(point);
            yield return point;
        }

        currentX = line.Start.X - dx;
        currentY = line.Start.Y - dy;

        while (IsValidX(currentX) && IsValidY(currentY))
        {
            currentX -= dx;
            currentY -= dy;

            var point = new Point2d(currentX, currentY);
            result.Add(point);
            yield return point;
        }
    }

    private static int Gcd(int dx, int dy)
    {
        while (dy != 0)
        {
            var temp = dy;
            dy = dx % dy;
            dx = temp;
        }

        return dx;
    }

    public List<Point2d> GetResonancePoints(AntennaLines lines)
    {
        var resonancePoints = new HashSet<Point2d>();

        foreach (var line in lines)
        {
            var resonancePointsInLine = GetResonancePointsInLine(line);
            foreach (var point in resonancePointsInLine)
            {
                resonancePoints.Add(point);
            }
        }

        return [.. resonancePoints];
    }

    public List<Point2d> GetResonancePointsInLine(AntennaLine line)
    {
        var ditanceX = line.End.X - line.Start.X;
        var distanceY = line.End.Y - line.Start.Y;

        var minX = line.Start.X - ditanceX;
        var minY = line.Start.Y - distanceY;

        var maxX = line.End.X + ditanceX;
        var maxY = line.End.Y + distanceY;

        var result = new List<Point2d>(2);

        if (IsValidX(minX) && IsValidY(minY))
        {
            var point = new Point2d(minX, minY);
            result.Add(point);
        }

        if (IsValidX(maxX) && IsValidY(maxY))
        {
            var point = new Point2d(maxX, maxY);
            result.Add(point);
        }

        return result;
    }

    private bool IsValidX(int x)
    {
        return x >= 0 && x < map.Width;
    }

    private bool IsValidY(int minY)
    {
        return minY >= 0 && minY < map.Height;
    }
}
