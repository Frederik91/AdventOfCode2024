using System;

namespace AdventOfCode.ApiService.Day6;

public class Guard
{
    public Point2d Location { get; set; }

    public Vector2d Direction { get; set; }
    public List<Position> Path { get; set; } = [];

    public Guard(Point2d position, Vector2d direction)
    {
        Location = position;
        Direction = direction;
        StorePosition();
    }

    private void StorePosition()
    {
        Position p = new(Location.Clone(), Direction);

        if (HasBeenHereBefore(p))
        {
            Path.Add(p);
            throw new InfiniteLoopException();
        }
        Path.Add(p);

    }

    public Point2d GetLocationAhead()
    {
        return new Point2d(Location.X + Direction.X, Location.Y + Direction.Y);
    }

    public void Move(int x, int y)
    {
        Location.X += x;
        Location.Y += y;
        StorePosition();
    }

    private bool HasBeenHereBefore(Position position)
    {
        var matchingPosition = Path.FirstOrDefault(p => p.Equals(position));
        return matchingPosition != null;
    }

    public void TurnRight()
    {
        var currentDirection = Direction;
        if (currentDirection.Equals(Vector2d.Up))
        {
            Direction = Vector2d.Right;
        }
        else if (currentDirection.Equals(Vector2d.Right))
        {
            Direction = Vector2d.Down;
        }
        else if (currentDirection.Equals(Vector2d.Down))
        {
            Direction = Vector2d.Left;
        }
        else if (currentDirection.Equals(Vector2d.Left))
        {
            Direction = Vector2d.Up;
        }

        StorePosition();
    }

    public void MoveForward()
    {
        Move(Direction.X, Direction.Y);
    }
}
