using AdventOfCode.ApiService;
using AdventOfCode.ApiService.Day1;
using AdventOfCode.ApiService.Day2;
using AdventOfCode.ApiService.Day3;
using AdventOfCode.ApiService.Day4;
using AdventOfCode.ApiService.Day5;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateSlimBuilder(args);

var app = builder.Build();

app.MapPost("day/{day}/part/{part}", (int day, int part, [FromBody] PuzzleInput body) =>
{
    var result = day switch
    {
        1 => Calculate<Day1Solver>(part, body.Input),
        2 => Calculate<Day2Solver>(part, body.Input),
        3 => Calculate<Day3Solver>(part, body.Input),
        4 => Calculate<Day4Solver>(part, body.Input),
        5 => Calculate<Day5Solver>(part, body.Input),
        > 24 => Results.BadRequest("Day must be between 1 and 24"),
        _ => Results.BadRequest("Day not solved yet")
    };

    return Results.Ok(result);
})
.Produces<int>()
.WithDescription("Calculates the result for the given day and part.");

static IResult Calculate<T>(int part, string input) where T : IDaySolver
{
    var solver = Activator.CreateInstance<T>();
    return part switch
    {
        1 => Results.Ok(solver.CalculatePartOne(input)),
        2 => Results.Ok(solver.CalculatePartTwo(input)),
        _ => Results.BadRequest("Only part 1 and 2 exists")
    };
}

app.Run();

public record PuzzleInput(string Input);