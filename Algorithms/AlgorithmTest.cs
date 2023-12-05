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

        [Fact]
        public void CanFormatSeparators()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
        }
        
        [Theory]
        [InlineData("a, b and c", new[]{"a", "b", "c"})]
        [InlineData("a, c, b and c", new[]{"a","c", "b", "c"})]
        public void CanFormatSeparators_Custom(string expected, string[] items)
        {
            Assert.Equal(expected, Algorithms.FormatSeparators(items));
        }
    }
}