namespace Day5;

public class UnitTest1
{
    [Fact]
    public void Example()
    {
        var example =
"""
47|53
47|61
47|29
75|53
75|61
75|13
75|47
97|75
61|29
61|53
53|29
53|13
97|13
97|61
47|13
97|47
75|29
61|13
29|13
97|29
97|53

75,47,61,53,29
""";

        var parsed = Parser.Parse(example);
        var sorter = new PageSorter(parsed.Rules);

        var result = sorter.SortPages(parsed.PageOrders[0].PageNumbers);

        Assert.Equal(parsed.PageOrders[0].PageNumbers, result);
    }

    [Fact]
    public void PartOne()
    {
        var input = File.ReadAllText("input.txt");

        var result = PageCalculator.CalculatePartOne(input);

        Assert.Equal(5955, result);
    }

    [Fact]
    public void PartTwo()
    {
        var input = File.ReadAllText("input.txt");

        var result = PageCalculator.CalculatePartTwo(input);

        Assert.Equal(4030, result);
    }
}
