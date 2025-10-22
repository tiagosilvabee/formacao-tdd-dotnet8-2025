namespace CarrinhoCompras.LogicLayer;

public class CarrinhoCompras
{
    public CarrinhoCompras()
    {
        if (produtos == null) {
            produtos = new List<Produto>();
        }
    }
    public List<Produto> produtos { get; set; }

    public Produto EncontraProdutoMaisBarato()
    {
        Produto produtoMaisBarato = null;
        foreach (Produto p in produtos)
        {
            if (produtoMaisBarato == null || produtoMaisBarato.preco > p.preco)
            {
                produtoMaisBarato = p;
            }
        }

        return produtoMaisBarato;
        ///Produtos.Min(x => x.preco);
    }
}s