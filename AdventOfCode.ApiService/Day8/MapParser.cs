using System;

namespace AdventOfCode.ApiService.Day8;

public static class MapParser
{
    public static Map Parse(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var antennas = new List<Antenna>();

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                var character = line[x];
                if (character== '.')
                {
                    continue;
                }


                var antenna = new Antenna(new (x, y), character);
                antennas.Add(antenna);
            }
        }

        var width = lines[0].Length;
        var height = lines.Length;

        return new Map(antennas, width, height);
    }
}
