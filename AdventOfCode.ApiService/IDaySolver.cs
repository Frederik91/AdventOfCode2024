using System;

namespace AdventOfCode.ApiService;

public interface IDaySolver
{
    int CalculatePartOne(string input);
    int CalculatePartTwo(string input);
}
