using System;

namespace AdventOfCode.ApiService;

public interface IDaySolver
{
    long CalculatePartOne(string input);
    long CalculatePartTwo(string input);
}
