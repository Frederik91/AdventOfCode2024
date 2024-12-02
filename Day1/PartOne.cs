using System;

namespace Day1;

public static class PartOne
{
    public static int Run()
    {
        var input = File.ReadLines("input.txt");
        var row1Numbers = new List<int>();
        var row2Numbers = new List<int>();

        foreach (var line in input)
        {
            var numbers = line.Split("   ");
            AddSorted(row1Numbers, int.Parse(numbers[0]));
            AddSorted(row2Numbers, int.Parse(numbers[1]));
        }

        var totalDistance = 0;
        for (int i = 0; i < row1Numbers.Count; i++)
        {
            var number1 = row1Numbers[i];
            var number2 = row2Numbers[i];
            var distance = Math.Abs(number1 - number2);
            totalDistance += distance;
        }

        return totalDistance;

        static void AddSorted(List<int> numbers, int number)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > number)
                {
                    numbers.Insert(i, number);
                    return;
                }
            }

            numbers.Add(number);
        }
    }
}
