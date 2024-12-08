namespace AdventOfCode.ApiService.Day6;

public class Simulation(Map map, Guard guard)
{
    public Map Map => map;
    public Guard Guard => guard;

    public Simulation Clone()
    {
        return new Simulation(map.Clone(), guard.Clone());
    }

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
