using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using AdventOfCode.ApiService;
using AdventOfCode.ApiService.Day1;
using AdventOfCode.ApiService.Day2;
using AdventOfCode.ApiService.Day3;
using AdventOfCode.ApiService.Day4;
using AdventOfCode.ApiService.Day5;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateSlimBuilder(args);

// Configure JSON options for AOT with SourceGenerationContext
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolver = SourceGenerationContext.Default;
});

var app = builder.Build();

app.MapPost("day/{day}/part/{part}", async (int day, int part, HttpRequest request) =>
{
    if (!request.HasFormContentType || !request.Form.Files.Any(f => f.Name == "puzzle-data"))
    {
        return Results.BadRequest("Missing puzzle-data file.");
    }

    var file = request.Form.Files["puzzle-data"];
    if (file is null)
    {
        return Results.BadRequest("Missing puzzle-data file.");
    }
    using var reader = new StreamReader(file.OpenReadStream());
    var input = await reader.ReadToEndAsync();

    var result = day switch
    {
        1 => Calculate<Day1Solver>(part, input),
        2 => Calculate<Day2Solver>(part, input),
        3 => Calculate<Day3Solver>(part, input),
        4 => Calculate<Day4Solver>(part, input),
        5 => Calculate<Day5Solver>(part, input),
        > 24 => Results.BadRequest("Day must be between 1 and 24"),
        _ => Results.BadRequest("Day not solved yet")
    };

    return result;
})
.Produces<int>()
.WithDescription("Calculates the result for the given day and part.");

static IResult Calculate<T>(int part, string input) where T : IDaySolver, new()
{
    var solver = new T();
    return part switch
    {
        1 => Results.Ok(solver.CalculatePartOne(input)),
        2 => Results.Ok(solver.CalculatePartTwo(input)),
        _ => Results.BadRequest("Only part 1 and 2 exists")
    };
}

app.Run();



[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(Ok<int>))]
[JsonSerializable(typeof(BadRequest<string>))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}