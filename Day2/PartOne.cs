using System;

namespace Day2;

public static class PartOne
{
    public static int Run()
    {
        var input = File.ReadAllText("input.txt");
        return CountSafeLines(input);
    }

    public static int CountSafeLines(string input)
    {
        var safeCount = 0;
        foreach (var line in input.Replace("\r", "").Split(Environment.NewLine))
        {
            if (IsValid(line))
            {
                safeCount++;
            }
        }

        return safeCount;
    }

    public static bool IsValid(string line)
    {
        var numbers = line.Split(" ").Select(int.Parse).ToArray();
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
