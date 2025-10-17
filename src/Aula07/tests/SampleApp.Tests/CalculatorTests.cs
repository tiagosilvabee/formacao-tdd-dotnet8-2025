using Xunit;

namespace SampleApp.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
            var calc = new SampleApp.Calculator();
            Assert.Equal(5, calc.Add(2, 3));
        }

        [Fact]
        public void Divide_ByZero_ShouldThrowException()
        {
            var calc = new SampleApp.Calculator();
            Assert.Throws<System.DivideByZeroException>(() => calc.Divide(5, 0));
        }
    }
}
