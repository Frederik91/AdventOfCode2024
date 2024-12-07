namespace AdventOfCode.ApiService.Day3;

public class Day3Solver : IDaySolver
{

    public int CalculatePartOne(string input)
    {
        return Parser.Parse(input).Sum();
    }

    public int CalculatePartTwo(string input)
    {
        return Parser.Parse(input, true).Sum();
    }
}
