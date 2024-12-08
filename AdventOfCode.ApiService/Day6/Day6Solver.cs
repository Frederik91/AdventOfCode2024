using System;

namespace AdventOfCode.ApiService.Day6;

public class Day6Solver : IDaySolver
{
    public int CalculatePartOne(string input)
    {
        var map = MapParser.Parse(input);
        var guard = new Guard(map.IntialPosition, Vector2d.Up);
        var simulation = new Simulation(map, guard);
        simulation.Run();

        var path = guard.Path;

        var distinctLocations = path.DistinctBy(x => x.Point).Count();

        return distinctLocations;
    }

    public int CalculatePartTwo(string input)
    {
        var map = MapParser.Parse(input);

        var loopLocationCount = 0;
        for (var row = 0; row < map.Height; row++)
        {
            for (var col = 0; col < map.Width; col++)
            {
                if (map.Obstacles[row][col] == 1)
                {
                    continue;
                }

                if (map.IntialPosition.X == col && map.IntialPosition.Y == row)
                {
                    continue;
                }

                try
                {
                    map.Obstacles[row][col] = 1;
                    var guard = new Guard(map.IntialPosition, Vector2d.Up);

                    var simulation = new Simulation(map, guard);
                    simulation.Run();
                }
                catch (InfiniteLoopException)
                {
                    loopLocationCount++;
                }
                finally
                {
                    map.Obstacles[row][col] = 0;
                }
            }
        }

        return loopLocationCount;
    }
}
