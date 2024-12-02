// See https://aka.ms/new-console-template for more information


using System.Diagnostics;

Console.WriteLine("Day 1");
Console.WriteLine("Part one");
var timer = Stopwatch.StartNew();
Day1.PartOne.Run();
timer.Stop();
Console.WriteLine($"Part one took {timer.ElapsedMilliseconds}ms");

Console.WriteLine("--------------------");
Console.WriteLine("Part two");
timer.Restart();
Day1.PartTwo.Run();
timer.Stop();
Console.WriteLine($"Part two took {timer.ElapsedMilliseconds}ms");