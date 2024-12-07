using System;
using AdventOfCode.ApiService.Day4;
using Xunit;

namespace AdventOfCode.ApiService.Tests.Day4;

public class MatrixBuilderTest
{
    [Fact]
    public void BuildMatrix_SingleLineInput_ReturnsCorrectMatrix()
    {
        // Arrange
        var input = "ABCDE";
        var expected = new char[][]
        {
            ['A', 'B', 'C', 'D', 'E']
        };

        // Act
        var result = MatrixBuilder.Build(input.AsSpan());

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void BuildMatrix_MultiLineInput_ReturnsCorrectMatrix()
    {
        // Arrange
        var input = "AB\nCD\nEF";
        var expected = new char[][]
        {
            ['A', 'B'],
            ['C', 'D'],
            ['E', 'F']
        };

        // Act
        var result = MatrixBuilder.Build(input.AsSpan());

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void BuildMatrix_InputWithTrailingNewline_ReturnsCorrectMatrix()
    {
        // Arrange
        var input = "AB\nCD\n";
        var expected = new char[][]
        {
            ['A', 'B'],
            ['C', 'D']
        };

        // Act
        var result = MatrixBuilder.Build(input.AsSpan());

        // Assert
        Assert.Equal(expected, result);
    }
}