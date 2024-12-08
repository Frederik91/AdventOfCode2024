using System;
using AdventOfCode.ApiService.Day6;

namespace AdventOfCode.ApiService.Tests.Day6;

public class GuardTests
{
    [Fact]
    public void StuckAtLoop_ThrowsException()
    {
        var guard = new Guard(new Point2d(0, 0), Vector2d.Up);
        guard.MoveForward();
        guard.TurnRight();

        guard.MoveForward();
        guard.TurnRight();

        guard.MoveForward();
        guard.TurnRight();

        guard.MoveForward();

        Assert.Throws<InfiniteLoopException>(() => guard.TurnRight());
    }
}
