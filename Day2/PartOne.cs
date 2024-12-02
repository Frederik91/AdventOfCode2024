using System;

namespace Day1;

public static class PartOne
{
    public static void Run()
    {
        var input = File.ReadLines("input.txt");

        var unsafeCount = 0;
        var safeCount = 0;
        foreach (var line in input)
        {
            var numbers = line.Split(" ").Select(int.Parse).ToArray();
            if (IsValid(numbers))
            {
                safeCount++;
            }
            else
            {
                unsafeCount++;
            }

        }

        Console.WriteLine("Safe: " + safeCount);
        Console.WriteLine("Unsafe: " + unsafeCount);
    }

    private static bool IsValid(Span<int> numbers)
    {
        var isIncreasing = numbers[0] < numbers[1];

        for (int i = 1; i < numbers.Length; i++)
        {
            var prev = numbers[i - 1];
            var current = numbers[i];

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
