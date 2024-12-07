namespace AdventOfCode.ApiService.Day3.Sequences;

public class StartSequence : ISequence
{
    public bool IsValid(ReadOnlySpan<char> input, out int skipLength)
    {
        skipLength = 1;
        if (input[0] != 'm')
        {
            return false;
        }

        if (input[1] != 'u')
        {
            return false;
        }
        skipLength++;

        if (input[2] != 'l')
        {
            return false;
        }
        skipLength++;

        if (input[3] != '(')
        {
            return false;
        }
        skipLength++;
        return true;
    }
}
