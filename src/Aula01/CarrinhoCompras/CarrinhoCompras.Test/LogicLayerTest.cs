namespace CarrinhoCompras.Test;

using CarrinhoCompras.LogicLayer;

[TestClass]
public class LogicLayerTest
{
    [TestMethod]
    public void DeveEncontrarProdutoMaisBaratoDoCarrinho()
    {
        //Arrange
        var carrinho = new CarrinhoCompras();
        var produto1 = new Produto { Id = 1, nome = "Biscoito", preco = 10M };
        var produto2 = new Produto { Id = 2, nome = "Café", preco = 70M };
        var produto3 = new Produto { Id = 3, nome = "Leite", preco = 170M };

        carrinho.produtos.Add(produto1);
        carrinho.produtos.Add(produto2);
        carrinho.produtos.Add(produto3);

        //Act
        Produto p = carrinho.EncontraProdutoMaisBarato();

        //Assert  
        Assert.AreEqual(10M, p.preco);
        Assert.AreEqual(produto1.preco, p.preco);
        Assert.AreEqual("Biscoito", p.nome);
        Assert.AreEqual(produto1.nome, p.nome);
    }
}