namespace AdventOfCode.ApiService.Day3.Sequences;

public class CommaSequence : ISequence
{
    public bool IsValid(ReadOnlySpan<char> input, out int skipLength)
    {
        skipLength = 0;
        if (input[0] != ',')
        {
            return false;
        }
        skipLength++;
        return true;
    }
}
