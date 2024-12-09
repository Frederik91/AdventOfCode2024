using System;

namespace AdventOfCode.ApiService.Day8;

public class AntennaLines
{
    private readonly Dictionary<(Point2d, Point2d), AntennaType> _lines = new();

    public void TryAdd(Point2d start, Point2d end, AntennaType type)
    {
        if (_lines.ContainsKey((start, end)))
        {
            return;
        }

        if (_lines.ContainsKey((end, start)))
        {
            return;
        }

        _lines.Add((start, end), type);
    }

    public IEnumerable<AntennaLine> GetLines()
    {
        foreach (var (key, value) in _lines)
        {
            yield return new AntennaLine(key.Item1, key.Item2, value);
        }
    }
}
