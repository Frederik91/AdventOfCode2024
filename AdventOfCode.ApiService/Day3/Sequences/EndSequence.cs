namespace AdventOfCode.ApiService.Day3.Sequences;

public class EndSequence : ISequence
{
    public bool IsValid(ReadOnlySpan<char> input, out int skipLength)
    {
        if (input[0] != ')')
        {
            skipLength = 0;
            return false;
        }
        skipLength = 1;
        return true;
    }
}
