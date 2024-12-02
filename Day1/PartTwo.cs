using System;

namespace Day1;

public static class PartTwo
{
    public static void Run()
    {
        var input = File.ReadLines("input.txt");
        var row1Numbers = new List<int>();
        var row2Numbers = new Dictionary<int, int>();

        foreach (var line in input)
        {
            var numbers = line.Split("   ");
            var num1 = int.Parse(numbers[0]);
            row1Numbers.Add(num1);

            var num2 = int.Parse(numbers[1]);
            if (row2Numbers.ContainsKey(num2))
            {
                row2Numbers[num2]++;
            }
            else
            {
                row2Numbers[num2] = 1;
            }
        }

        var sum = 0;
        foreach (var number in row1Numbers)
        {
            if (row2Numbers.TryGetValue(number, out var count))
            {
                sum += number * count;
            }
        }

        Console.WriteLine(sum);
    }
}
