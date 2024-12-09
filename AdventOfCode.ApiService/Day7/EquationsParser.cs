using System;

namespace AdventOfCode.ApiService.Day7;

public class EquationsParser
{
    public static List<Equation> Parse(string input)
    {
        var equations = new List<Equation>();
        var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            var parts = line.Split(":", StringSplitOptions.RemoveEmptyEntries);
            var expectedValue = long.Parse(parts[0].Trim());
            var values = parts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            equations.Add(new Equation(expectedValue, values));
        }

        return equations;
    }
}
