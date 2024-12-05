using System;

namespace Day4;

public class CrossMasFinder
{
    internal static int Count(string input)
    {
        var matrix = MatrixBuilder.Build(input.AsSpan());
        int masCount = CountMas(matrix);

        return masCount;
    }

    internal static int CountMas(char[][] matrix)
    {
        var masCount = 0;
        for (var row = 1; row < matrix.Length - 1; row++)
        {
            for (var column = 1; column < matrix[0].Length - 1; column++)
            {
                var character = matrix[row][column];
                if (character != 'A')
                {
                    continue;
                }

                var topLeft = matrix[row - 1][column - 1];
                var bottomRight = matrix[row + 1][column + 1];

                if (IsMas(topLeft, character, bottomRight) == false)
                {
                    continue;
                }

                var topRight = matrix[row - 1][column + 1];
                var bottomLeft = matrix[row + 1][column - 1];

                if (IsMas(topRight, character, bottomLeft) == false)
                {
                    continue;
                }

                masCount++;
            }
        }

        return masCount;
    }

    private static bool IsMas(char topLeft, char character, char bottomRight)
    {
        if ( topLeft == 'M' && character == 'A' && bottomRight == 'S')
        {
            return true;
        }

        if ( topLeft == 'S' && character == 'A' && bottomRight == 'M')
        {
            return true;
        }

        return false;
    }
}
