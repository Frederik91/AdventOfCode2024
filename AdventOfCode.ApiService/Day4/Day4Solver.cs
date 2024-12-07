namespace AdventOfCode.ApiService.Day4;

public class Day4Solver : IDaySolver
{
    public int CalculatePartOne(string input)
    {
        return XmasFinder.Count(input);
    }

    public int CalculatePartTwo(string input)
    {
        return CrossMasFinder.Count(input);
    }
}
