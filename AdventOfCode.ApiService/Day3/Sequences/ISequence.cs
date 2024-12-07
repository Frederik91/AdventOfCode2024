namespace AdventOfCode.ApiService.Day3.Sequences;

public interface ISequence
{
    bool IsValid(ReadOnlySpan<char> input, out int skipLength);
}
