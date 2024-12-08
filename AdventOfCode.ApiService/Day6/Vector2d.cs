using System;

namespace AdventOfCode.ApiService.Day6;

public class Vector2d(int x, int y)
{
    public static Vector2d Up => new(0, -1);
    public static Vector2d Right => new(1, 0);
    public static Vector2d Down => new(0, 1);
    public static Vector2d Left => new(-1, 0);

    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    public override bool Equals(object? obj)
    {
        if (obj is not Vector2d other)
        {
            return false;
        }

        return X == other.X && Y == other.Y;
    }

    internal Vector2d Clone()
    {
        return new Vector2d(X, Y);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}
