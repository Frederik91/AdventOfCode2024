using System;

namespace AdventOfCode.ApiService.Day6;

public class Point2d(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    public Point2d Clone() => new(X, Y);

    public override string ToString() => $"({X}, {Y})";

    public override bool Equals(object? obj)
    {
        if (obj is not Point2d point)
        {
            return false;
        }

        return X == point.X && Y == point.Y;
    }

    public override int GetHashCode() => HashCode.Combine(X, Y);
}
