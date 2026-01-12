using Xunit;
using itbXLib;

namespace itbXLib.Tests
{
    public class RecursivesTests
    {
        [Fact]
        public void Countdown_ShouldReturnZero()
        {
            Assert.Equal(0, Recursives.Countdown(5));
        }

        [Theory]
        [InlineData(5, 1)]
        [InlineData(10, 2)]
        [InlineData(999, 3)]
        public void CountDigits_ShouldReturnCorrectCount(int n, int expected)
        {
            Assert.Equal(expected, Recursives.CountDigits(n));
        }

        [Theory]
        [InlineData(12, 3)]
        [InlineData(99, 18)]
        public void AddDigits_ShouldReturnSumOfDigits(int n, int expected)
        {
            Assert.Equal(expected, Recursives.AddDigits(n));
        }

        [Theory]
        [InlineData(123, 321)]
        [InlineData(100, 1)]
        public void Swap_ShouldInvertNumber(int n, int expected)
        {
            Assert.Equal(expected, Recursives.Swap(n));
        }

        [Fact]
        public void FindMax_ShouldReturnHighestValue()
        {
            int[] array = { 3, 7, 2, 9, 1 };
            Assert.Equal(9, Recursives.FindMax(array, 0));
        }

        [Theory]
        [InlineData("ana", true)]
        [InlineData("hola", false)]
        public void IsPalindrome_ShouldIdentifyPalindromes(string word, bool expected)
        {
            Assert.Equal(expected, Recursives.IsPalindrome(word));
        }

        [Theory]
        [InlineData(12, 8, 4)]
        [InlineData(7, 3, 1)]
        public void MCD_ShouldCalculateGreatestCommonDivisor(int a, int b, int expected)
        {
            Assert.Equal(expected, Recursives.MCD(a, b));
        }

        [Theory]
        [InlineData(0, "0")]
        [InlineData(13, "1101")]
        public void DecimalToBinary_ShouldReturnCorrectString(int n, string expected)
        {
            Assert.Equal(expected, Recursives.DecimalToBinary(n));
        }
    }
}