using System;
using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Fact]
        public void CanGetFactorial()
        {
            Assert.Equal(24, Algorithms.GetFactorial(4));
        }

        [Theory]
        [InlineData(24, 4)]
        [InlineData(3628800,10)]
        [InlineData(120,5)]
        [InlineData(720, 6)]
        [InlineData(1, 1)]
        [InlineData(1, 0)]
        public void CanGetFactorial_Custom(int expected, int n)
        {
            Assert.Equal(expected, Algorithms.GetFactorial(n));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        public void GetFactorial_NegativeParameter_Should_Throw_ArgumentOutOfRangeException(int n)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Algorithms.GetFactorial(n));
        }



        [Fact]
        public void CanFormatSeparators()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
        }
        
        [Theory]
        [InlineData("a, b and c", new[]{"a", "b", "c"})]
        [InlineData("a, b, b and c", new[]{"a", "b", "b", "c"})]
        [InlineData("a, c, b and c", new[]{"a","c", "b", "c"})]
        public void CanFormatSeparators_Custom(string expected, string[] items)
        {
            Assert.Equal(expected, Algorithms.FormatSeparators(items));
        }
    }
}