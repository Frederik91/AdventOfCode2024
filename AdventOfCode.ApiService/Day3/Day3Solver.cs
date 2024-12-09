namespace AdventOfCode.ApiService.Day3;

public class Day3Solver : IDaySolver
{

    public long CalculatePartOne(string input)
    {
        return Parser.Parse(input).Sum();
    }

    public long CalculatePartTwo(string input)
    {
        return Parser.Parse(input, true).Sum();
    }
}
