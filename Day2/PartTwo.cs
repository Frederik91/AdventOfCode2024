using System;
using System.Diagnostics.CodeAnalysis;

namespace Day2;

public static class PartTwo
{
    public static int Run()
    {
        var input = File.ReadLines("input.txt");

        var unsafeCount = 0;
        var safeCount = 0;
        foreach (var line in input)
        {
            var isValid = IsLineValid(line);
            safeCount += isValid ? 1 : 0;
            unsafeCount += isValid ? 0 : 1;
        }

        return safeCount;
    }

    public static bool IsLineValid(string line)
    {
        var numbers = line.Split(" ").Select(int.Parse).ToArray();
        if (IsValid(numbers, out var invalidIndexes))
        {
            return true;
        }

        var variants = invalidIndexes.Select(x => GetValuesExceptIndex(numbers, x)).ToArray();
        if (variants.Any(x => IsValid(x, out _)))
        {
            return true;
        }

        return false;
    }

    private static int[] GetValuesExceptIndex(int[] numbers, int index)
    {
        return numbers.Take(index).Concat(numbers.Skip(index + 1)).ToArray();
    }

    private static bool IsValid(Span<int> numbers, [NotNullWhen(false)] out int[]? invalidIndexes)
    {
        invalidIndexes = null;
        var isIncreasing = numbers[0] < numbers[1];

        for (int i = 1; i < numbers.Length; i++)
        {
            var prev = numbers[i - 1];
            var current = numbers[i];

            if (IsValid(isIncreasing, prev, current) == false)
            {
                if (i > 1)
                {
                    invalidIndexes = [i - 2, i - 1, i];
                }
                else
                {
                    invalidIndexes = [i - 1, i];
                }

                return false;
            }
        }
        return true;
    }

    private static bool IsValid(bool isIncreasing, int prev, int current)
    {
        if (isIncreasing == false && current >= prev)
        {
            return false;
        }

        if (isIncreasing && current <= prev)
        {
            return false;
        }

        if (IsTooFarApart(prev, current))
        {
            return false;
        }

        return true;
    }

    private static bool IsTooFarApart(int prev, int current)
    {
        var distFromPrev = Math.Abs(current - prev);
        if (distFromPrev > 3)
        {
            return true;
        }

        return false;
    }
}
