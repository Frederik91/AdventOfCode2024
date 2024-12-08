using System;

namespace AdventOfCode.ApiService.Day6;

public class Simulation(Map map, Guard guard)
{
    public void Run()
    {
        while (true)
        {
            try
            {
                MoveToNextObstacle();
                if (map.IsOutOfBounds(guard.Location))
                {
                    break;
                }

                guard.TurnRight();
            }
            catch (OutOfMapException)
            {
                break;
            }
        }
    }

    private void MoveToNextObstacle()
    {
        while (map.MoveGuardForward(guard))
        {
            if (map.IsOutOfBounds(guard.Location))
            {
                break;
            }
        }
    }
}
