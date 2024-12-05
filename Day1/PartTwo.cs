using System;

namespace Day1;

public static class PartTwo
{
    public static int Run()
    {
        var input = File.ReadAllText("input.txt");
        return Calculate(input);
    }

    public static int Calculate(string input)
    {
        var row1Numbers = new List<int>();
        var row2Numbers = new Dictionary<int, int>();

        foreach (var line in input.Replace("\r", "").Split(Environment.NewLine))
        {
            var numbers = line.Split("   ");
            var num1 = int.Parse(numbers[0]);
            row1Numbers.Add(num1);

            var num2 = int.Parse(numbers[1]);
            row2Numbers[num2] += 1;
        }

        var sum = 0;
        foreach (var number in row1Numbers)
        {
            if (row2Numbers.TryGetValue(number, out var count))
            {
                sum += number * count;
            }
        }

        return sum;
    }
}
