namespace AdventOfCode.ApiService.Day3.Sequences;

public class NumberSequence : ISequence
{
    public int Number { get; private set; }

    public bool IsValid(ReadOnlySpan<char> input, out int skipLength)
    {
        var digitCount = 0;
        while (char.IsDigit(input[digitCount]))
        {
            digitCount++;
        }

        skipLength = digitCount;
        if (digitCount > 0 && digitCount <= 3)
        {
            Number = int.Parse(input[..digitCount]);
            return true;
        }
        Number = 0;
        return false;
    }
}
