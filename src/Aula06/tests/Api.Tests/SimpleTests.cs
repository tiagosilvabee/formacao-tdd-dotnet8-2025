namespace Api.Tests;

public class SimpleTests
{
    [Fact]
    public void Soma_DeveRetornarResultadoCorreto()
    {
        var resultado = 2 + 3;
        Assert.Equal(5, resultado);
    }

    [Fact]
    public void Api_DeveResponderHelloWorld()
    {
        var mensagem = "Hello from GitHub Actions CI 👋";
        Assert.Contains("GitHub Actions", mensagem);
    }
}
