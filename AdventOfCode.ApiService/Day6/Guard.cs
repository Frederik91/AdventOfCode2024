using System;

namespace AdventOfCode.ApiService.Day6;

public class Guard
{
    public Point2d Position { get; set; }

    public Vector2d Direction { get; set; }
    public List<Point2d> Path { get; set; } = [];

    public Guard(Point2d position, Vector2d direction)
    {
        Position = position;
        Path.Add(Position.Clone());
        Direction = direction;
    }

    internal Point2d GetLocationAhead()
    {
        return new Point2d(Position.X + Direction.X, Position.Y + Direction.Y);
    }

    public void Move(int x, int y)
    {
        Position.X += x;
        Position.Y += y;
        Path.Add(Position.Clone());
    }

    public void TurnRight()
    {
        var currentDirection = Direction;
        if (currentDirection == Vector2d.Up)
        {
            Direction = Vector2d.Right;
        }
        else if (currentDirection == Vector2d.Right)
        {
            Direction = Vector2d.Down;
        }
        else if (currentDirection == Vector2d.Down)
        {
            Direction = Vector2d.Left;
        }
        else if (currentDirection == Vector2d.Left)
        {
            Direction = Vector2d.Up;
        }
    }

    internal void MoveForward()
    {
        Move(Direction.X, Direction.Y);
    }
}
