using System;

namespace AdventOfCode.ApiService.Day8;

public class Day8Solver : IDaySolver
{
    public long CalculatePartOne(string input)
    {
        var map = MapParser.Parse(input);

        var lines = map.GetLines();

        var resonancePoints = new ResonanceFinder(map).GetResonancePoints(lines);

        return resonancePoints.Count;
    }

    public long CalculatePartTwo(string input)
    {
        var map = MapParser.Parse(input);

        var lines = map.GetLines();

        var resonancePoints = new ResonanceFinder(map).GetResonanceLines(lines);

        return resonancePoints.Count;
    }
}
