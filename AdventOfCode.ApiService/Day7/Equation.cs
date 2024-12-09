using System;

namespace AdventOfCode.ApiService.Day7;

public class Equation(long expectedValue, int[] values)
{
    public long ExpectedValue { get; } = expectedValue;
    public int[] Values { get; } = values;

    public bool EvaluateCanBeSolved()
    {
        if (Values.Length == 1)
        {
            return Values[0] == ExpectedValue;
        }

        var combinations = GenerateVariations(Values.Length - 1);
        foreach (var combination in combinations)
        {
            long sum = Values[0];
            for (var i = 0; i < combination.Length; i++)
            {
                if (combination[i] == 0)
                {
                    sum += Values[i + 1];
                }
                else
                {
                    sum *= Values[i + 1];
                }
            }

            if (sum == ExpectedValue)
            {
                return true;
            }
        }

        return false;
    }

    private static int[][] GenerateVariations(int length)
    {
        int totalValues = 1 << length;
        int[][] sequences = new int[totalValues][];

        for (int i = 0; i < totalValues; i++)
        {
            int[] sequence = new int[length];
            for (int bit = 0; bit < length; bit++)
            {
                // Extract bits from left to right
                sequence[bit] = (i >> (length - bit - 1)) & 1;
            }
            sequences[i] = sequence;
        }

        return sequences;
    }
}
