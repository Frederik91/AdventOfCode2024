using Day5;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateSlimBuilder(args);

var app = builder.Build();

app.MapPost("day/{day}/part/{part}", (int day, int part, [FromBody] PuzzleInput body) =>
{
    var result = day switch
    {
        1 => part switch
        {
            1 => Results.Ok(Day1.PartOne.Calculate(body.Input)),
            2 => Results.Ok(Day1.PartTwo.Calculate(body.Input)),
            _ => Results.BadRequest("Only part 1 and 2 exists")
        },
        2 => part switch
        {
            1 => Results.Ok(Day2.PartOne.CountSafeLines(body.Input)),
            2 => Results.Ok(Day2.PartTwo.CountSafeLines(body.Input)),
            _ => Results.BadRequest("Only part 1 and 2 exists")
        },
        3 => part switch
        {
            1 => Results.Ok(Day3.Parser.Parse(body.Input, includeDisable: false).Sum()),
            2 => Results.Ok(Day3.Parser.Parse(body.Input, includeDisable: true).Sum()),
            _ => Results.BadRequest("Only part 1 and 2 exists")
        },
        4 => part switch
        {
            1 => Results.Ok(Day4.XmasFinder.Count(body.Input)),
            2 => Results.Ok(Day4.CrossMasFinder.Count(body.Input)),
            _ => Results.BadRequest("Only part 1 and 2 exists")
        },
        5 => part switch
        {
            1 => Results.Ok(PageCalculator.CalculatePartOne(body.Input)),
            2 => Results.Ok(PageCalculator.CalculatePartTwo(body.Input)),
            _ => Results.BadRequest("Only part 1 and 2 exists")
        },
        > 24 => Results.BadRequest("Day must be between 1 and 24"),
        _ => Results.BadRequest("Day not found")
    };

    return Results.Ok(result);
})
.Produces<int>()
.WithDescription("Calculates the result for the given day and part.");

app.Run();

public record PuzzleInput(string Input);