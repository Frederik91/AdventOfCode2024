using System;

namespace Day3;

public interface ISequence
{
    bool IsValid(ReadOnlySpan<char> input, out int skipLength);
}

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

public class Parser
{


    internal static List<int> Parse(string input, bool includeDisable = false)
    {
        var sequences = new List<ISequence>
        {
            new StartSequence(),
            new NumberSequence(),
            new CommaSequence(),
            new NumberSequence(),
            new EndSequence()
        };

        var result = new List<int>();
        var span = input.AsSpan();
        bool isDisabled = false;
        while (span.Length > 0)
        {
            if (isDisabled)
            {
                if (IsEnableFlag(span))
                {
                    isDisabled = false;
                    span = span[4..];
                    continue;
                }
                span = span[1..];
                continue;
            }

            var isValid = false;
            foreach (var sequence in sequences)
            {
                if (span.Length == 0)
                {
                    isValid = false;
                    break;
                }
                isValid = sequence.IsValid(span, out var skipLength);
                span = span[skipLength..];
                if (!isValid)
                {
                    break;
                }
            }

            if (isValid)
            {
                var numbers = sequences.OfType<NumberSequence>().Select(x => x.Number).ToArray();
                result.Add(numbers[0] * numbers[1]);
            }

            if (includeDisable && IsDisableFlag(span))
            {
                isDisabled = true;
                span = span[7..];
            }
        }
        return result;

    }

    public static bool IsEnableFlag(ReadOnlySpan<char> span)
    {
        if (span.Length < 4)
        {
            return false;
        }
        return span[0] == 'd'
            && span[1] == 'o'
            && span[2] == '('
            && span[3] == ')';
    }

    public static bool IsDisableFlag(ReadOnlySpan<char> span)
    {
        if (span.Length < 7)
        {
            return false;
        }
        return span[0] == 'd'
            && span[1] == 'o'
            && span[2] == 'n'
            && span[3] == '\''
            && span[4] == 't'
            && span[5] == '('
            && span[6] == ')';
    }
}
