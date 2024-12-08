using System;
using AdventOfCode.ApiService.Day6;

namespace AdventOfCode.ApiService.Tests.Day6;

public class MapTests
{
    [Fact]
    public void StopsAtObstacle()
    {
        var obstacles = new int[][]
        {
            [0, 1, 0],
            [0, 0, 0],
            [0, 0, 0]
        };
        var map = new Map(3, 3, obstacles, new Point2d(1, 1));
        var guard = new Guard(map.IntialPosition, Vector2d.Up);

        var nextPosition = guard.GetLocationAhead();
        Assert.Equal(new Point2d(0, 1), nextPosition);

        var canMoveAhead = map.MoveGuardForward(guard);
        Assert.False(canMoveAhead);
    }

    [Fact]
    public void CanMoveOutOfBounds()
    {
        var obstacles = new int[][]
        {
            [0, 0, 0],
            [0, 1, 0],
            [0, 0, 0]
        };
        var map = new Map(3, 3, obstacles, new Point2d(1, 0));
        var guard = new Guard(map.IntialPosition, Vector2d.Up);

        map.MoveGuardForward(guard);
        var isOutOfBounds = map.IsOutOfBounds(guard.Location);
        Assert.True(isOutOfBounds);
    }
}
