namespace AdventOfCode.ApiService.Day1;

public class Day1Solver : IDaySolver
{
    public int CalculatePartOne(string input)
    {
        var row1Numbers = new List<int>();
        var row2Numbers = new List<int>();


        foreach (var line in input.Replace("\r", "").Split(Environment.NewLine))
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
    }

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

    public int CalculatePartTwo(string input)
    {
        var row1Numbers = new List<int>();
        var row2Numbers = new Dictionary<int, int>();

        foreach (var line in input.Replace("\r", "").Split(Environment.NewLine))
        {
            var numbers = line.Split("   ");
            var num1 = int.Parse(numbers[0]);
            row1Numbers.Add(num1);

            var num2 = int.Parse(numbers[1]);
            if (!row2Numbers.TryGetValue(num2, out _))
            {
                row2Numbers[num2] = 0;
            }
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
