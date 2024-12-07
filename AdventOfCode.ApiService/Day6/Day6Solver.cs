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

        var distinctLocations = path.Distinct().Count();

        return distinctLocations;
    }

    public int CalculatePartTwo(string input)
    {
        throw new NotImplementedException();
    }
}
