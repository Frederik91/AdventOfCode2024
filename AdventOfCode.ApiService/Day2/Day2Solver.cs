using System;

namespace AdventOfCode.ApiService.Day2;

public class Day2Solver : IDaySolver
{
    public long CalculatePartOne(string input)
    {
        return PartOne.CountSafeLines(input);
    }

    public long CalculatePartTwo(string input)
    {
        return PartTwo.CountSafeLines(input);
    }
}
