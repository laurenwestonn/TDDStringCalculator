using FluentAssertions;
using System;
using Xunit;

namespace StringCalculator.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("", 0)]
        public void Add_EmptyString_ReturnsZero(string input, int expected)
        {
            // Arrange
            var calc = new Calculator();
            // Act
            var result = calc.Add(input);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("0", 0)]
        public void Add_OneNumber_ReturnsNumber(string input, int expected)
        {
            var calc = new Calculator();
            calc.Add(input).Should().Be(expected);
        }

        [Theory]
        [InlineData("1,1", 2)]
        [InlineData("1,2", 3)]
        [InlineData("0,2", 2)]
        public void Add_TwoNumbers_ReturnsSum(string input, int expected)
        {
            var calc = new Calculator();
            calc.Add(input).Should().Be(expected);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("1,2,3,4", 10)]
        [InlineData("1,2,3,4,0", 10)]
        public void Add_AnyAmountOfNumbers(string input, int expected)
        {
            var calc = new Calculator();
            calc.Add(input).Should().Be(expected);
        }

        [Theory]
        [InlineData("1\n2", 3)]
        [InlineData("1\n2,3", 6)]
        [InlineData("1,2\n3\n4", 10)]
        public void Add_AllowCommaAndNewLineDelimiters(string input, int expected)
        {
            var calc = new Calculator();
            calc.Add(input).Should().Be(expected);
        }

        [Fact]
        public void Add_SpecifyDelimiter()
        {
            "//;\n1;2".ShouldCalculateTo(3);
            "//~\n1~2~3".ShouldCalculateTo(6);
        }

        [Theory]
        [InlineData("-1", "Negatives not allowed: -1")]
        [InlineData("1,-2", "Negatives not allowed: -2")]
        [InlineData("1,-2,-3", "Negatives not allowed: -2,-3")]
        public void Add_Negatives_ThrowException(string input, string expected)
        {
            var calc = new Calculator();
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => calc.Add(input));

            ex.ParamName.Should().Be(expected);
        }
    }

    internal static class TestHelper
    {
        public static void ShouldCalculateTo(this string input, int expected)
        {
            var calc = new Calculator();
            Assert.Equal(expected, calc.Add(input));
        }
    }
}
