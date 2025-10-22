using Xunit;

namespace TestLegibilidade.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void Deposit_ShouldIncreaseBalance()
        {
            //Arrange
            var account = new BankAccount("123", 100m);

            //Act
            account.Deposit(50m);
            
            //Assert
            Assert.Equal(150m, account.Balance);
        }

        [Theory]
        [InlineData(200, 50, 150)]
        [InlineData(100, 100, 0)]
        public void Withdraw_ShouldDecreaseBalance(decimal initialBalance, decimal value, decimal balance)
        {
            //Arrange
            var account = new BankAccount("321", initialBalance);

            //Act
            account.Withdraw(value);
            
            //Assert
            Assert.Equal(balance, account.Balance);
        }

        [Fact]
        public void Withdraw_ShouldThrowError()
        {
            //Arrange
            var account = new BankAccount("555", 100m);
            
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(200m));
        }
    }
}