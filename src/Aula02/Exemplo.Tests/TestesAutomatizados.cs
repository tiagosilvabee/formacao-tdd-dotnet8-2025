
using System.Text;

[TestClass]
public class TestesAutomatizados
{

    [TestMethod]
    public void DeveriaPassarNoProcessoDeTestesAutomatizados()
    {
        //Arrange
        var exemplo = new StringBuilder();

        //Act
        //Assert
        Assert.IsTrue(true);
        Assert.AreEqual(1, 1);
        Assert.IsFalse(false);
        Assert.IsInstanceOfType(exemplo, typeof(StringBuilder));
    }


    [TestMethod]
    [TestCategory("ProcessoDeTestesAutomatizados")]
    public void NaoDeveriaPassarNoProcessoDeTestesAutomatizados()
    {
        Assert.IsTrue(true, "Corrigido exemplificar o processo de testes automatizados.");
    }

    [TestMethod]
    [TestCategory("ProcessoDeTestesAutomatizados")]
    public void DeveriaPassarNoProcessoDeTestesAutomatizadosSoma()
    {
        Assert.AreEqual(2, 2);
    }


    [TestMethod]
    [ExpectedException(typeof(NotImplementedException))]
    public void DeveEstourarUmaExcecaoTesteComBug()
    {
        throw new NotImplementedException("Exceção proposital para exemplificar o processo de testes automatizados.");
    }

}