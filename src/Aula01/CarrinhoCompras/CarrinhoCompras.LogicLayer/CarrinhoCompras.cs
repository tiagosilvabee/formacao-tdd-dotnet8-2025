namespace CarrinhoCompras.LogicLayer;

public class CarrinhoCompras
{
    public CarrinhoCompras()
    {
        if (Produtos == null)
        {
            Produtos = new List<Produto>();
        }
    }
    public List<Produto> Produtos { get; set; }

    public Produto EncontraMaisBarato3()
    {
        Produto produtoMaisBarato = null;
        foreach (var item in Produtos)
        {
            if (produtoMaisBarato == null || produtoMaisBarato.Preco > item.Preco || item.Preco == 0)
            {
                produtoMaisBarato = item;
            }
        }

        return produtoMaisBarato;
    }

    // public Produto EncontraMaisBarato()
    // {
    //     return Produtos.OrderBy(x => x.Preco).FirstOrDefault();
    // }

}