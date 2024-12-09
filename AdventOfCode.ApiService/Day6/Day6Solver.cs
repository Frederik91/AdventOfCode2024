using System;

namespace AdventOfCode.ApiService.Day6;

public class Day6Solver : IDaySolver
{
    public long CalculatePartOne(string input)
    {
        var map = MapParser.Parse(input);
        var guard = new Guard(map.IntialPosition, Vector2d.Up);
        var simulation = new Simulation(map, guard);
        simulation.Run();

        var path = guard.Path;

        var distinctLocations = path.DistinctBy(x => x.Point).Count();

        return distinctLocations;
    }

    public long CalculatePartTwo(string input)
    {
        var map = MapParser.Parse(input);

        var loopLocationCount = 0;

        var dryRun = new Simulation(map, new Guard(map.IntialPosition, Vector2d.Up));
        dryRun.Run();

        var attemptedlocations = new HashSet<Point2d>();
        foreach (var position in dryRun.Guard.Path.Skip(1))
        {
            if (!attemptedlocations.Add(position.Point))
            {
                continue;
            }

            map.Obstacles[position.Point.Y][position.Point.X] = 1;
            try
            {
                var simulation = new Simulation(map, new Guard(map.IntialPosition, Vector2d.Up));
                simulation.Run();
            }
            catch (InfiniteLoopException)
            {
                loopLocationCount++;
            }
            finally
            {
                map.Obstacles[position.Point.Y][position.Point.X] = 0;
            }
        }

        return loopLocationCount;
    }
}
