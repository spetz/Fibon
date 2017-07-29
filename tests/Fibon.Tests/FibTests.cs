using Fibon.Service;
using Xunit;

namespace Fibon.Tests
{
    public class FibTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(7, 13)]
        public void Fib_ReturnsCorrectValues(int number, int expectedResults)
        {
            ICalculator calc = new Fast();
            int result = calc.Fib(number);

            Assert.Equal(expectedResults, result);
        }

    }
}
