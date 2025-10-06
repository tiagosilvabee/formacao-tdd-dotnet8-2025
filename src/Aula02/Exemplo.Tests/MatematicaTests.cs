using System.Text;
using Exemplo.Console;

namespace Exemplo.Tests;



[TestClass]
public sealed class Test1
{
    [TestInitialize]
    public void Inicializar()
    {
        // Executado antes de cada classe de teste        
        var path = $"{Environment.CurrentDirectory}\\arquivo.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Conteúdo inicial do arquivo de teste.");
        }        
    }

    [TestCleanup]
    public void Finalizar()
    {
        // Executado antes de cada classe de teste
        var path = $"{Environment.CurrentDirectory}\\arquivo.txt";
        if (File.Exists(path))
        {
            File.Delete(path);
        }        
    }


    [TestMethod]
    [TestCategory("Matematica")]
    public void DeveriaPassarNoProcessoDeTestesAutomatizadosSomaComMetodo()
    {
        var resultado = Matematica.Somar(2, 2);
        Assert.AreEqual(4, resultado);
    }

    [TestMethod]
    [TestCategory("Matematica")]
    public void DeveriaPassarNoProcessoDeTestesAutomatizadosSomaZerosComMetodo()
    {
        var resultado = Matematica.Somar(0, 0);
        Assert.AreEqual(0, resultado);
    }


    [TestMethod]
    [TestCategory("Matematica")]
    public void DeveriaPassarNoProcessoDeTestesAutomatizadosSomaNegativosComMetodo()
    {
        var resultado = Matematica.Somar(-2, -2);
        Assert.AreEqual(-4, resultado);
    }

    [TestMethod]
    [DataRow(2, 2, 4)]
    [DataRow(-2, -2, -4)]
    [DataRow(-12, -12, -24)]
    [DataRow(-2, 2, 0)]
    [DataRow(-4, -12, -16)]    
[TestCategory("Matematica")]
    public void DeveriaPassarNoProcessoDeTestesAutomatizadosSomaDataRow(int a, int b, int resultadoEsperado)
    {
        var resultado = Matematica.Somar(a, b);
        Assert.AreEqual(resultadoEsperado, resultado);
    }


    [TestMethod]
    [TestCategory("Matematica")]
    public void DeveriaPassarNoProcessoDeTestesAutomatizadosSubtrairComMetodo()
    {
        var resultado = Matematica.Subtrair(2, 2);
        Assert.AreEqual(0, resultado);
    }


    [TestMethod]
    public void DeveriaPassarNoProcessoDeTestesAutomatizadosFormulaBaskaraComMetodo()
    {
        var resultado = Matematica.FormulaBaskara(1, -3, 2);
        Assert.AreEqual(1, resultado);
    }
}
