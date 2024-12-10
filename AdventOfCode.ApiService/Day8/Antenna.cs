using System;

namespace AdventOfCode.ApiService.Day8;

public class Antenna(Point2d location, char type)
{
    public Point2d Location { get; set; } = location;
    public char Type { get; set; } = type;
}
