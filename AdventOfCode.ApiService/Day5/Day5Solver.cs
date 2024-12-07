namespace AdventOfCode.ApiService.Day5;

public class Day5Solver : IDaySolver
{
    public int CalculatePartOne(string input)
    {
        var parsed = Parser.Parse(input);
        var sorter = new PageSorter(parsed.Rules);

        var result = 0;
        foreach (var pageOrder in parsed.PageOrders)
        {
            var sortedPages = sorter.SortPages(pageOrder.PageNumbers);

            if (pageOrder.PageNumbers.SequenceEqual(sortedPages) == false)
                continue;

            var middleNumberIndex = sortedPages.Length / 2;
            var middleNumber = sortedPages[middleNumberIndex];
            result += middleNumber;
        }

        return result;
    }

    public int CalculatePartTwo(string input)
    {
        var parsed = Parser.Parse(input);
        var sorter = new PageSorter(parsed.Rules);

        var result = 0;
        foreach (var pageOrder in parsed.PageOrders)
        {
            var sortedPages = sorter.SortPages(pageOrder.PageNumbers);

            if (pageOrder.PageNumbers.SequenceEqual(sortedPages))
                continue;

            var middleNumberIndex = sortedPages.Length / 2;
            var middleNumber = sortedPages[middleNumberIndex];
            result += middleNumber;
        }

        return result;
    }
}
