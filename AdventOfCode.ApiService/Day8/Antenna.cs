using System;

namespace AdventOfCode.ApiService.Day8;

public enum AntennaType
{
    Lowercase,
    Uppercase,
    Number
}
public class Antenna(Point2d location, AntennaType type)
{
    public Point2d Location { get; set; } = location;
    public AntennaType Type { get; set; } = type;
}
