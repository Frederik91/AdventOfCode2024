using System;

namespace AdventOfCode.ApiService.Day6;

public static class MapParser
{
    public static Map Parse(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var height = lines.Length;
        var width = lines[0].Length;
        var obstacles = new int[height][];
        Point2d? initialPosition = null;
        for (var i = 0; i < lines.Length; i++)
        {
            obstacles[i] = new int[width];
            for (var j = 0; j < width; j++)
            {
                var character = lines[i][j];
                obstacles[i][j] = character == '#' ? 1 : 0;
                if (character == '^')
                {
                    initialPosition = new Point2d(j, i);
                }
            }
        }

        if (initialPosition == null)
        {
            throw new InvalidOperationException("Initial position not found");
        }


        var map = new Map(lines[0].Length, lines.Length, obstacles, initialPosition);

        return map;
    }
}
