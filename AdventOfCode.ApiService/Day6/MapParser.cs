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
        for (var row = 0; row < lines.Length; row++)
        {
            obstacles[row] = new int[width];
            for (var col = 0; col < width; col++)
            {
                var character = lines[row][col];
                obstacles[row][col] = character == '#' ? 1 : 0;
                if (character == '^')
                {
                    initialPosition = new Point2d(col, row);
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
