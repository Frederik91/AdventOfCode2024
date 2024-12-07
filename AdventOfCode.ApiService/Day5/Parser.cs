using System;

namespace AdventOfCode.ApiService.Day5;

public record Rule(int PageNumber, int DependentPageNumber)
{
    public static Rule Parse(string input)
    {
        var parts = input.Trim().Split("|");
        return new Rule(int.Parse(parts[0]), int.Parse(parts[1]));
    }
}

public record PageOrder(int[] PageNumbers)
{
    public static PageOrder Parse(string input)
    {
        var parts = input.Split(",");
        var pageNumbers = parts
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(int.Parse)
            .ToArray();

        return new PageOrder(pageNumbers);
    }
}

public record ParseResult(Rule[] Rules, PageOrder[] PageOrders);

public class Parser
{
    public static ParseResult Parse(string input)
    {
        input = input.Replace("\r", "");
        var parts = input.Split(Environment.NewLine + Environment.NewLine);

        var rules = parts[0].Split(Environment.NewLine)
            .Select(Rule.Parse)
            .ToArray();

        var pageOrders = parts[1]
            .Split(Environment.NewLine)
            .Select(PageOrder.Parse)
            .ToArray();

        return new ParseResult(rules, pageOrders);
    }
}
