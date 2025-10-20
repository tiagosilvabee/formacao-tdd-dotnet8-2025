using calculator.lib;
using calculator.lib.Model;
using calculator.lib.Services;
using Moq;

namespace calculator.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //Arrange
        var mock = new Mock<ICalculator>();
        mock.Setup(calc => calc.Somar(2, 1)).Returns(3);

        //Act
        ICalculator calc = mock.Object;
        var valorCalculado = calc.Somar(2, 1);

        //Assert
        Assert.Equal(3, valorCalculado);
    }

    [Fact]
    public void TestarApoliceTradicional()
    {
        //Arrange
        var prd = new Produto { Id = 1, Nome = "teste", PremioMaximo = 10000M };
        var cli = new Cliente { Id = 1, Nome = "cliente", DataNascimento = new DateTime(2000, 10, 20) };
        var police = new Apolice { Id = 1, ObjetoDoSeguro = prd, Segurado = cli };

        //Act
        var valorPremio = police.ValorPremio();

        //Assert
        Assert.Equal(91310, valorPremio);
    }

    [Fact]
    public void TestarApoliceComMock()
    {
        //Arrange
        var mock = new Mock<ICalculoApolice>();
        mock.Setup(calc => calc.ValorPremio()).Returns(91310);

        //Act
        ICalculoApolice calc = mock.Object;
        var valorCalculado = calc.ValorPremio();

        //Assert
        Assert.Equal(91310, valorCalculado);
    }
}
