using System;

namespace AdventOfCode.ApiService.Day7;

public class Day7Solver : IDaySolver
{
    public long CalculatePartOne(string input)
    {
        var equations = EquationsParser.Parse(input);
        var canBeSolved = equations.Where(x => x.EvaluateCanBeSolved()).ToList();
        
        return canBeSolved.Sum(x => x.ExpectedValue);
    }

    public long CalculatePartTwo(string input)
    {
        var equations = EquationsParser.Parse(input);
        Concatinator.AddConcatinateAlternatives(equations);
        var canBeSolved = equations.Where(x => x.EvaluateCanBeSolved()).ToList();

        return canBeSolved.Sum(x => x.ExpectedValue);
    }
}
