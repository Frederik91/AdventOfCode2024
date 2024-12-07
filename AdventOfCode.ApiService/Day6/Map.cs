using System;

namespace AdventOfCode.ApiService.Day6;

public class Map(int width, int height, int[][] obstacles, Point2d intialPosition)
{
    public int Width { get; } = width;
    public int Height { get; } = height;
    public Point2d IntialPosition { get; } = intialPosition;

    public int[][] Obstacles { get; } = obstacles;

    internal bool IsGuardOutOfBounds(Guard guard)
    {
        return guard.Position.X < 0 || guard.Position.X >= Width || guard.Position.Y < 0 || guard.Position.Y >= Height;
    }

    internal bool MoveGuardForward(Guard guard)
    {
        var nextPosition = guard.GetLocationAhead();
        if (IsObstacle(nextPosition))
        {
            return false;
        }

        guard.MoveForward();
        return true;
    }

    private bool IsObstacle(Point2d nextPosition)
    {
        return Obstacles[nextPosition.X][nextPosition.Y] == 1;        
    }
}
