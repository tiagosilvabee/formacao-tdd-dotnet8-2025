namespace Api.Tests;

public class SimpleTests
{
    [Fact]
    public void Soma_DeveRetornarResultadoCorreto()
    {
        var resultado = 3 + 2;
        Assert.Equal(5, resultado);
    }

    [Fact]
    public void Api_DeveResponderHelloWorld()
    {
        var mensagem = "Hello from GitHub Actions CI 👋";
        Assert.Contains("GitHub Actions", mensagem);
    }
}
