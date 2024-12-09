namespace AdventOfCode.ApiService.Day4;

public class Day4Solver : IDaySolver
{
    public long CalculatePartOne(string input)
    {
        return XmasFinder.Count(input);
    }

    public long CalculatePartTwo(string input)
    {
        return CrossMasFinder.Count(input);
    }
}
