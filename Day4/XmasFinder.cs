using System;
using System.Runtime.InteropServices.Marshalling;

namespace Day4;

public static class XmasFinder
{
    public static int Count(string input)
    {
        var span = input.AsSpan();

        var matrix = MatrixBuilder.Build(span);

        var count = CountXMasesInMatrix(matrix);
        return count;
    }

    internal static int CountXMasesInMatrix(char[][] matrix)
    {
        var rowCounts = CountXMasesInRows(matrix);
        var columnCounts = CountXMasesInColumns(matrix);
        var diagonalCounts = CountXMasesInDiagonals(matrix);

        return rowCounts + columnCounts + diagonalCounts;
    }

    private static int CountXMasesInDiagonals(char[][] matrix)
    {
        var diagonals = CreateDiagonals(matrix);

        var count = 0;
        foreach (var diagonal in diagonals)
        {
            count += CountXMasesInArray(diagonal);
        }
        return count;
    }

    internal static List<char[]> CreateDiagonals(char[][] matrix)
    {
        var diagonals = new List<char[]>();

        // Scan left to right diagonals
        for (var column = 0; column < matrix[0].Length; column++)
        {
            var diagonal = new List<char>();
            for (var row = 0; row < matrix.Length; row++)
            {
                var columnIndex = column + row;
                if (columnIndex >= matrix[0].Length)
                {
                    break;
                }
                var character = matrix[row][columnIndex];
                diagonal.Add(character);
            }

            if (diagonal.Count > 3)
                diagonals.Add([.. diagonal]);
        }

        // Scan right to left diagonals
        for (var column = matrix[0].Length - 1; column >= 0; column--)
        {
            var diagonal = new List<char>();
            for (var row = 0; row < matrix.Length; row++)
            {
                var columnIndex = column - row;
                if (columnIndex < 0)
                {
                    break;
                }
                var character = matrix[row][columnIndex];
                diagonal.Add(character);
            }

            if (diagonal.Count > 3)
                diagonals.Add([.. diagonal]);
        }

        return diagonals;
    }

    private static int CountXMasesInColumns(char[][] matrix)
    {
        var count = 0;
        for (var column = 0; column < matrix[0].Length; column++)
        {
            var columnCharacters = new char[matrix.Length];
            for (var row = 0; row < matrix.Length; row++)
            {
                columnCharacters[row] = matrix[row][column];
            }

            count += CountXMasesInArray(columnCharacters);
        }

        return count;
    }

    internal static int CountXMasesInRows(char[][] matrix)
    {
        var count = 0;
        foreach (var row in matrix)
        {
            count += CountXMasesInArray(row);
        }

        return count;
    }

    internal static int CountXMasesInArray(char[] row)
    {
        var count = 0;
        for (var i = 0; i < row.Length; i++)
        {
            if (IsXmasForward(row, i))
            {
                count++;
                i += 3;
            }
            else if (IsXmasBackward(row, i))
            {
                count++;
                i += 3;
            }
        }

        return count;
    }

    private static bool IsXmasBackward(char[] characters, int i)
    {
        if (i + 3 >= characters.Length)
        {
            return false;
        }
        return characters[i] == 'S' && characters[i + 1] == 'A' && characters[i + 2] == 'M' && characters[i + 3] == 'X';
    }

    private static bool IsXmasForward(char[] characters, int i)
    {
        if (i + 3 >= characters.Length)
        {
            return false;
        }
        return characters[i] == 'X' && characters[i + 1] == 'M' && characters[i + 2] == 'A' && characters[i + 3] == 'S';
    }
}
