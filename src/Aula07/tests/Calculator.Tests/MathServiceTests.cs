
using Xunit;

namespace Calculator.Tests;

public class MathServiceTests
{
    [Fact]
    public void Add_ShouldReturnSum()
    {
        Assert.Equal(5, MathService.Add(2, 3));
    }

    [Fact]
    public void Subtract_ShouldReturnDifference()
    {
        Assert.Equal(1, MathService.Subtract(3, 2));
    }
}
