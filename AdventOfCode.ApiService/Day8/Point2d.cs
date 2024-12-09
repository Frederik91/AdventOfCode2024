using System;

namespace AdventOfCode.ApiService.Day8;

public record Vector2d(int X, int Y)
{
    public double Length { get; } = Math.Sqrt(X * X + Y * Y);
}

public record Point2d(int X, int Y)
{
    public static Vector2d operator -(Point2d a, Point2d b)
    {
        return new Vector2d(a.X - b.X, a.Y - b.Y);
    }
}