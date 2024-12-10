using System;

namespace AdventOfCode.ApiService.Day8;

public class Map(List<Antenna> antennas, int width, int height)
{
    public Dictionary<char, Dictionary<Point2d, Antenna>> Antennas { get; } = antennas
        .GroupBy(x => x.Type)
        .ToDictionary(g => g.Key, g => g.ToDictionary(a => a.Location));

    public int Width { get; } = width;
    public int Height { get; } = height;

    public AntennaLines GetLines()
    {
        var lines = new AntennaLines();
        foreach (var antenna in antennas)
        {
            ScanForAntennaLines(antenna, lines);
        }

        return lines;
    }

    private void ScanForAntennaLines(Antenna antenna, AntennaLines antennaLines)
    {        
        // Scan horizontally
        for (var x = 0; x < Width; x++)
        {
            if (x == antenna.Location.X)
            {
                continue;
            }
            var location = new Point2d(x, antenna.Location.Y);
            if (Antennas[antenna.Type].ContainsKey(location))
            {
                antennaLines.TryAdd(antenna.Location, location, antenna.Type);
            }
        }

        // Scan vertically
        for (var y = 0; y < Height; y++)
        {
            if (y == antenna.Location.Y)
            {
                continue;
            }

            var location = new Point2d(antenna.Location.X, y);
            if (Antennas[antenna.Type].ContainsKey(location))
            {
                antennaLines.TryAdd(antenna.Location, location, antenna.Type);
            }
        }

        // Scan diagonally (top-left to bottom-right)
        for (var x = 0; x < Width; x++)
        {
            for (var y = 0; y < Height; y++)
            {
                if (x == antenna.Location.X || y == antenna.Location.Y)
                {
                    continue;
                }

                var location = new Point2d(x, y);
                if (Antennas[antenna.Type].ContainsKey(location))
                {
                    antennaLines.TryAdd(antenna.Location, location, antenna.Type);
                }
            }
        }

        // Scan diagonally (top-right to bottom-left)
        for (var x = 0; x < Width; x++)
        {
            for (var y = 0; y < Height; y++)
            {
                if (x == antenna.Location.X || y == antenna.Location.Y)
                {
                    continue;
                }

                var location = new Point2d(x, y);
                if (Antennas[antenna.Type].ContainsKey(location))
                {
                    antennaLines.TryAdd(antenna.Location, location, antenna.Type);
                }
            }
        }
    }
}
