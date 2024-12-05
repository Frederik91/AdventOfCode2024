using System;
using Xunit;

namespace Day4.Tests;

public class XmasFinderTest
{
    [Fact]
    public void PartOne()
    {
        var input = File.ReadAllText("input.txt");
        var result = XmasFinder.Count(input);

        Assert.True(result > 1614);
    }

    [Fact]
    public void Example()
    {
        var input =
"""
MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX
""";

        var result = XmasFinder.Count(input);

        Assert.Equal(18, result);
    }

    [Fact]
    public void CountXMasesInRow_ShouldReturnZero_WhenNoXmasPresent()
    {
        // Arrange
        var row = "ABCDEFGH".ToCharArray();

        // Act
        var result = XmasFinder.CountXMasesInArray(row);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void CountXMasesInRow_ShouldReturnOne_WhenOneXmasPresentForward()
    {
        // Arrange
        var row = "XMAS".ToCharArray();

        // Act
        var result = XmasFinder.CountXMasesInArray(row);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void CountXMasesInRow_ShouldReturnOne_WhenOneXmasPresentBackward()
    {
        // Arrange
        var row = "SAMX".ToCharArray();

        // Act
        var result = XmasFinder.CountXMasesInArray(row);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void CountXMasesInRow_ShouldReturnTwo_WhenTwoXmasPresent()
    {
        // Arrange
        var row = "XMASXMAS".ToCharArray();

        // Act
        var result = XmasFinder.CountXMasesInArray(row);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void CountXMasesInRow_ShouldReturnTwo_WhenOneXmasForwardAndOneBackward()
    {
        // Arrange
        var row = "XMASSAMX".ToCharArray();

        // Act
        var result = XmasFinder.CountXMasesInArray(row);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void CountXMasesInRow_ShouldReturnZero_WhenXmasIsIncomplete()
    {
        // Arrange
        var row = "XMA".ToCharArray();

        // Act
        var result = XmasFinder.CountXMasesInArray(row);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void CreateDiagonals_ShouldReturnCorrectDiagonals_ForSquareMatrix()
    {
        // Arrange
        char[][] matrix =
        [
                ['A', 'B', 'C', 'D'],
                ['E', 'F', 'G', 'H'],
                ['I', 'J', 'K', 'L'],
                ['M', 'N', 'O', 'P'],
        ];

        // Act
        var diagonals = XmasFinder.CreateDiagonals(matrix);

        // Assert
        Assert.Equal(2, diagonals.Count);
        Assert.Equal(['A', 'F', 'K', 'P'], diagonals[0]);
        Assert.Equal(['D', 'G', 'J', 'M'], diagonals[1]);
    }

    [Fact]
    public void CountXMassesInMatrix_ShouldReturnOne_Horizontal()
    {
        char[][] matrix =
        [
            ['0', '0', '0', '0', '0'],
            ['X', 'M', 'A', 'S', '0'],
            ['0', '0', '0', '0', '0'],
            ['0', '0', 'O', '0', '0'],
            ['0', 'S', 'A', 'M', 'X'],
        ];

        var result = XmasFinder.CountXMasesInMatrix(matrix);

        Assert.Equal(2, result);
    }

    [Fact]
    public void CountXMassesInMatrix_ShouldReturnCorrectCount_DiagonalRLForwardXMas()
    {
        char[][] matrix =
        [
            ['A', 'B', 'C', 'X', 'X'],
            ['E', 'F', 'M', 'M', 'X'],
            ['I', 'A', 'A', 'L', 'X'],
            ['S', 'S', 'O', 'P', 'X'],
            ['S', 'S', 'O', 'P', 'X'],
        ];

        var result = XmasFinder.CountXMasesInMatrix(matrix);

        Assert.Equal(2, result);
    }

    [Fact]
    public void CountXMassesInMatrix_ShouldReturnCorrectCount_DiagonalRLReverseXMas()
    {
        char[][] matrix =
        [
            ['A', 'B', 'C', 'S', 'X'],
            ['E', 'F', 'A', 'S', 'X'],
            ['I', 'M', 'A', 'L', 'X'],
            ['X', 'M', 'O', 'P', 'X'],
            ['X', 'S', 'O', 'P', 'X'],
            ['X', 'S', 'O', 'P', 'X'],
            ['X', 'S', 'O', 'S', 'X'],
            ['X', 'S', 'A', 'P', 'X'],
            ['X', 'M', 'O', 'P', 'X'],
            ['X', 'S', 'O', 'P', 'X'],
        ];

        var result = XmasFinder.CountXMasesInMatrix(matrix);

        Assert.Equal(3, result);
    }
}