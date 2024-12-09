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


                var antenna = ParseAntenna(x, y, character);
                antennas.Add(antenna);
            }
        }

        var width = lines[0].Length;
        var height = lines.Length;

        return new Map(antennas, width, height);
    }

    private static Antenna ParseAntenna(int x, int y, char character)
    {
        if (char.IsDigit(character))
        {
            return new Antenna(new(x, y), AntennaType.Number);
        }

        if (char.IsUpper(character))
        {
            return new Antenna(new(x, y), AntennaType.Uppercase);
        }

        if (char.IsLower(character))
        {
            return new Antenna(new(x, y), AntennaType.Lowercase);
        }

        throw new NotSupportedException($"Character {character} is not supported");
    }
}
