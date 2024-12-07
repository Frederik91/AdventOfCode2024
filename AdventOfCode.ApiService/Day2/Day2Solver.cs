using System;

namespace AdventOfCode.ApiService.Day2;

public class Day2Solver : IDaySolver
{
    public int CalculatePartOne(string input)
    {
        return PartOne.CountSafeLines(input);
    }

    public int CalculatePartTwo(string input)
    {
        return PartTwo.CountSafeLines(input);
    }
}
