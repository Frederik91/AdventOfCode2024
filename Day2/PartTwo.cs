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

        var variants = GetVariants(numbers, invalidIndexes);
        return variants.Any(x => IsValid(x, out _));
    }

    private static int[][] GetVariants(int[] numbers, int[] invalidIndexes)
    {
        return invalidIndexes.Select(x => GetValuesExceptIndex(numbers, x)).ToArray();
    }

    private static int[] GetValuesExceptIndex(int[] numbers, int index)
    {
        var result = new int[numbers.Length - 1];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (i == index)
            {
                continue;
            }
            var insertIndex = i > index ? i - 1 : i;
            result[insertIndex] = numbers[i];
        }
        return result;
    }

    private static bool IsValid(Span<int> numbers, [NotNullWhen(false)] out int[]? invalidIndexes)
    {
        invalidIndexes = null;
        var isIncreasing = numbers[0] < numbers[1];

        for (int i = 1; i < numbers.Length; i++)
        {
            var prev = numbers[i - 1];
            var current = numbers[i];

            if (IsValid(isIncreasing, prev, current))
                continue;

            invalidIndexes = CalculateInvalidIndexes(i);

            return false;
        }

        return true;
    }

    private static int[] CalculateInvalidIndexes(int i)
    {
        int[]? invalidIndexes;
        if (i > 1)
        {
            invalidIndexes = [i - 2, i - 1, i];
        }
        else
        {
            invalidIndexes = [i - 1, i];
        }

        return invalidIndexes;
    }

    private static bool IsValid(bool isIncreasing, int prev, int current)
    {
        if (IsChangingDirection(isIncreasing, prev, current))
        {
            return false;
        }

        if (IsTooFarApart(prev, current))
        {
            return false;
        }

        return true;
    }

    private static bool IsChangingDirection(bool isIncreasing, int prev, int current)
    {
        if (isIncreasing == false && current >= prev)
        {
            return true;
        }

        if (isIncreasing && current <= prev)
        {
            return true;
        }

        return false;
    }

    private static bool IsTooFarApart(int prev, int current)
    {
        return Math.Abs(current - prev) > 3;
    }
}
