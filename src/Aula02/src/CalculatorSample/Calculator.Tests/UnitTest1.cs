using Calculator;
using FluentAssertions;

namespace Calculator.Tests;

public class UnitTest1
{
    [Fact]
    public void Sum_ShouldReturnCorrectValue()
    {
        var calculator = new Calculator();
        var result = calculator.Sum(2, 3);
        result.Should().Be(5);
    }
}
