using System;

namespace AdventOfCode.ApiService.Day6;

public class Map(int width, int height, int[][] obstacles, Point2d intialPosition)
{
    public int Width { get; } = width;
    public int Height { get; } = height;
    public Point2d IntialPosition { get; } = intialPosition;

    public int[][] Obstacles { get; } = obstacles;
    public bool IsOutOfBounds(Point2d point)
    {
        return point.X < 0 || point.X >= Width || point.Y < 0 || point.Y >= Height;
    }

    public bool MoveGuardForward(Guard guard)
    {
        var nextPosition = guard.GetLocationAhead();
        if (IsObstacle(nextPosition))
        {
            return false;
        }

        guard.MoveForward();
        return true;
    }

    public bool IsObstacle(Point2d nextPosition)
    {
        if (IsOutOfBounds(nextPosition))
        {
            throw new OutOfMapException();
        }
        return Obstacles[nextPosition.Y][nextPosition.X] == 1;        
    }
}
