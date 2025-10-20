namespace calculator.lib.Model;

using calculator.lib.Services;


public class Apolice : ICalculoApolice
{
    public int Id { get; set; }
    public Cliente? Segurado { get; set; }
    public Produto? ObjetoDoSeguro { get; set; }

    public decimal ValorPremio()
    {
        var dataAtual = new DateTime(2025, 10, 20);
        var idadeCliente = dataAtual.Subtract(Segurado.DataNascimento).Days;
        return 10 * idadeCliente;
    }
}