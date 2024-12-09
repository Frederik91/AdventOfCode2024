using System;

namespace AdventOfCode.ApiService.Day7;

public static class Concatinator
{
    internal static void AddConcatinateAlternatives(List<Equation> equations)
    {
        var concatinations = new List<Equation>();
        foreach (var equation in equations)
        {
            if (equation.Values.Length == 1)
            {
                continue;
            }

            for (var i = 0; i < equation.Values.Length - 1; i++)
            {
                var values = equation.Values.ToList();

                // Get current value and the next value
                var currentValue = values[i].ToString();
                var nextValue = values[i + 1].ToString();
                var value = int.Parse(currentValue + nextValue);
                values.RemoveAt(i);
                values.RemoveAt(i);
                values.Insert(i, value);

                var concatination = new Equation(equation.ExpectedValue, [.. values]);
                concatinations.Add(concatination);
            }
        }

        equations.AddRange(concatinations);
    }
}
