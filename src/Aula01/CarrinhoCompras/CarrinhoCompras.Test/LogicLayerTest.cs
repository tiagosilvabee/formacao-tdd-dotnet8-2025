namespace CarrinhoCompras.Test;

using CarrinhoCompras.LogicLayer;

[TestClass]
public class LogicLayerTest
{
    [TestMethod]
    public void DeveEncontrarOProdutoMaisBaratoNoCarrinho()
    {
        //Arrange
        var carrinho = new CarrinhoCompras();
        var produto1 = new Produto { Id = 1, Nome = "Biscoito", Preco = 10M };
        var produto2 = new Produto { Id = 2, Nome = "Café", Preco = 70M };
        var produto3 = new Produto { Id = 3, Nome = "Leite", Preco = 170M };

        carrinho.Produtos.Add(produto1);
        carrinho.Produtos.Add(produto2);
        carrinho.Produtos.Add(produto3);

        //Act
        var produtoMaisBarato = carrinho.EncontraMaisBarato();

        //Assert
        //Expected/Actual
        Assert.AreEqual(10M, produtoMaisBarato.Preco);
        Assert.AreEqual(produto1.Preco, produtoMaisBarato.Preco);
    }


    [TestMethod]
    public void DeveEncontrarOProdutoMaisBaratoNoCarrinhoEmOrdemCrescente()
    {
        //Arrange
        var carrinho = new CarrinhoCompras();
        var produto1 = new Produto { Id = 1, Nome = "Biscoito", Preco = 10M };
        var produto2 = new Produto { Id = 2, Nome = "Café", Preco = 70M };
        var produto3 = new Produto { Id = 3, Nome = "Leite", Preco = 170M };

        carrinho.Produtos.Add(produto1);
        carrinho.Produtos.Add(produto2);
        carrinho.Produtos.Add(produto3);

        //Act
        var produtoMaisBarato = carrinho.EncontraMaisBarato();

        //Assert
        //Expected/Actual
        Assert.AreEqual(10M, produtoMaisBarato.Preco);
        Assert.AreEqual(produto1.Preco, produtoMaisBarato.Preco);
    }


    [TestMethod]
    public void DeveEncontrarOProdutoMaisBaratoNoCarrinhoEmOrdemDecrescente()
    {
        //Arrange
        var carrinho = new CarrinhoCompras();
        var produto1 = new Produto { Id = 1, Nome = "Biscoito", Preco = 10M };
        var produto2 = new Produto { Id = 2, Nome = "Café", Preco = 70M };
        var produto3 = new Produto { Id = 3, Nome = "Leite", Preco = 170M };

        carrinho.Produtos.Add(produto3);
        carrinho.Produtos.Add(produto2);
        carrinho.Produtos.Add(produto1);

        //Act
        var produtoMaisBarato = carrinho.EncontraMaisBarato();

        //Assert
        //Expected/Actual
        Assert.AreEqual(10M, produtoMaisBarato.Preco);
        Assert.AreEqual(produto1.Preco, produtoMaisBarato.Preco);
    }



    [TestMethod]
    public void DeveEncontrarOProdutoMaisBaratoNoCarrinhoQuandoOProdutoNaoTemValor()
    {
        //Arrange
        var carrinho = new CarrinhoCompras();
        var produto1 = new Produto { Id = 1, Nome = "Biscoito", Preco = 0M };
        var produto2 = new Produto { Id = 2, Nome = "Café", Preco = 70M };
        var produto3 = new Produto { Id = 3, Nome = "Leite", Preco = 170M };
        
        carrinho.Produtos.Add(produto1);        
        carrinho.Produtos.Add(produto2);
        carrinho.Produtos.Add(produto3);

        //Act
        var produtoMaisBarato = carrinho.EncontraMaisBarato();

        //Assert
        //Expected/Actual
        Assert.AreEqual(0M, produtoMaisBarato.Preco);
        Assert.AreEqual(produto1.Preco, produtoMaisBarato.Preco);
    }
    

        [TestMethod]
    public void DeveEncontrarOProdutoMaisBaratoNoCarrinhoQuandoDoisProdutosTemValoresIguaisEscolhendoOPrimeiroMaisBarato()
    {
        //Arrange
        var carrinho = new CarrinhoCompras();
        var produto1 = new Produto { Id = 1, Nome = "Biscoito", Preco = 70M };
        var produto2 = new Produto { Id = 2, Nome = "Café", Preco = 70M };
        var produto3 = new Produto { Id = 3, Nome = "Leite", Preco = 170M };
        
        carrinho.Produtos.Add(produto1);        
        carrinho.Produtos.Add(produto2);
        carrinho.Produtos.Add(produto3);
       
        //Act
        var produtoMaisBarato = carrinho.EncontraMaisBarato();

        //Assert
        //Expected/Actual
        Assert.AreEqual(70M, produtoMaisBarato.Preco);
        Assert.AreEqual("Biscoito", produtoMaisBarato.Nome);
        Assert.AreEqual(produto1.Preco, produtoMaisBarato.Preco);
    }
}