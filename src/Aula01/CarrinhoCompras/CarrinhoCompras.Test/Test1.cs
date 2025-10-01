namespace CarrinhoCompras.Test;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void DeveCalcularOValorDeFormaCorreta()
    {
        //Arrange
        var a = 1;
        var b = 2;

        //Act
        var resultado = a + b;

        //Assert
        //expected/actual
        Assert.AreEqual(3, resultado);
    }

    [TestMethod]
    [ExpectedException(typeof(System.DivideByZeroException))]
    public void DeveCalcularOValorDeFormaErradaEVaiDarErro()
    {
        //Arrange
        var a = 1;
        var b = 0;

        //Act
        var resultado = a / b;

        //Assert
        //expected/actual
        //Assert.AreEqual(3, resultado);
    }
}
