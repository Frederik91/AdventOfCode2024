using System;

namespace AdventOfCode.ApiService.Day6;

public class Simulation(Map map, Guard guard)
{
    public void Run()
    {
        while (!map.IsGuardOutOfBounds(guard))
        {
            MoveToNextObstacle();
            guard.TurnRight();
        }
    }

    private void MoveToNextObstacle()
    {

        while (map.MoveGuardForward(guard))
        {
            if (map.IsGuardOutOfBounds(guard))
            {
                break;
            }
        }
    }
}
