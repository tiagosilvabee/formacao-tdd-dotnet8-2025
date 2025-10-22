namespace CarrinhoCompras.Test;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        //Arrange
        var a = 5;
        var b = 6;

        //Act
        var resultado = a + b;

        //Assert
        //expected/actual
        Assert.AreEqual(11, resultado);
    }

    [TestMethod]
    public void TestMethod2()
    {
        //Arrange
        var a = 5;
        var b = 6;

        //Act
        var resultado = a + b;

        //Assert
        //expected/actual
        Assert.AreNotEqual(3, resultado);
    }

    [TestMethod]
    [ExpectedException(typeof(System.DivideByZeroException))]
    public void TestMethod3()
    {
        //Arrange
        var a = 5;
        var b = 0;

        //Act
        var resultado = a / b;

        //Assert
        //expected/actual
        //Assert.AreNotEqual(3, resultado);
    }
}
