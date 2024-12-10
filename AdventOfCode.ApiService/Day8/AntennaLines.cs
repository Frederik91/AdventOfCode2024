using System;
using System.Collections;

namespace AdventOfCode.ApiService.Day8;

public class AntennaLines : IEnumerable<AntennaLine>
{
    private readonly Dictionary<(Point2d, Point2d), char> _lines = new();

    public AntennaLines()
    {
        
    }

    public AntennaLines(IEnumerable<AntennaLine> lines)
    {
        foreach (var line in lines)
        {
            _lines.Add((line.Start, line.End), line.Type);
        }
    }

    public void TryAdd(Point2d start, Point2d end, char type)
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

    public IEnumerator<AntennaLine> GetEnumerator()
    {
         foreach (var (key, value) in _lines)
        {
            yield return new AntennaLine(key.Item1, key.Item2, value);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
