using System;

namespace AdventOfCode.ApiService.Day4;

public class MatrixBuilder
{
    public static char[][] Build(ReadOnlySpan<char> input)
    {
        int columns = CalculateColumns(input);
        int rows = CalculateRows(input);
        var matrix = new char[rows][];
        matrix[0] = new char[columns];
        var row = 0;
        var column = 0;
        while (input.Length > 0)
        {
            var character = input[0];
            input = input[1..];
            if (character == '\n')
            {
                if (input.Length == 0)
                {
                    break;
                }
                row++;
                column = 0;
                matrix[row] = new char[columns];
            }
            else
            {
                matrix[row][column] = character;
                column++;
            }
        }

        return matrix;
    }

    private static int CalculateRows(ReadOnlySpan<char> input)
    {
        var rows = input.Count('\n');
        if (input[^1] != '\n')
        {
            rows++;
        }

        return rows;
    }

    private static int CalculateColumns(ReadOnlySpan<char> input)
    {
        var width = input.IndexOf('\n');
        if (width == -1)
        {
            return input.Length;
        }
        return width;
    }
}
