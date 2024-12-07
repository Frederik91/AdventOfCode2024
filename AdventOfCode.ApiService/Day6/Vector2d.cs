using System;

namespace AdventOfCode.ApiService.Day6;

public class Vector2d(int x, int y)
{
    internal static Vector2d Up = new(0, 1);
    internal static Vector2d Right = new(1, 0);
    internal static Vector2d Down = new(0, -1);
    internal static Vector2d Left = new(-1, 0);

    public int X { get; set; } = x;
    public int Y { get; set; } = y;
}
