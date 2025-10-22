# Sessão 4 — Escrevendo Testes Legíveis e Evitando Anti-patterns

## 🎯 Objetivos

* Aprender boas práticas de escrita de testes legíveis e manuteníveis.
* Identificar e evitar **anti-patterns comuns** em testes.
* Refatorar testes ruins para maior clareza e confiabilidade.
* Exercitar cobertura de cenários positivos e negativos de forma clara.

---

## 📚 Material Teórico

### 1️⃣ Boas práticas na escrita de testes

* **Nomes descritivos:** explique o que o teste faz, ex.: `Withdraw_ShouldThrow_WhenSaldoInsuficiente`.
* **Estrutura AAA (Arrange-Act-Assert):** organize o teste para ficar claro o que é preparação, ação e verificação.
* **Granularidade:** cada teste deve testar **uma única lógica**.
* **Clareza > quantidade:** prefira testes simples e fáceis de entender do que muitos testes complexos.

Exemplo de teste legível:

```csharp
[Fact]
public void Deposit_ShouldIncreaseBalance()
{
    // Arrange
    var account = new BankAccount("123", 100m);

    // Act
    account.Deposit(50m);

    // Assert
    Assert.Equal(150m, account.Balance);
}
```

---

### 2️⃣ Anti-patterns comuns

| Anti-pattern            | Problema                                           | Exemplo                                   |
| ----------------------- | -------------------------------------------------- | ----------------------------------------- |
| Testes frágeis          | Quebram facilmente com mudanças pequenas no código | Testa detalhes internos de implementação  |
| Mocks excessivos        | Teste se torna dependente de muitas simulações     | Mocka tudo e não testa comportamento real |
| Over-testing            | Testa detalhes irrelevantes ou redundantes         | Testa getter/setter simples               |
| Testes confusos         | Nomes ou estrutura não explicam a lógica           | `Test1()` sem contexto                    |
| Testes interdependentes | Resultado depende da execução de outro teste       | Depende de saldo criado por outro teste   |

---

### 3️⃣ Refatorando testes ruins

* Separe **cenários positivos** (funciona como esperado) de **cenários negativos** (exceções, erros).
* Evite testes gigantes que fazem várias validações.
* Prefira **asserts claros** ao invés de lógica complexa dentro do teste.
* Mantenha a **estrutura AAA** sempre visível.

---

### 4️⃣ Dicas rápidas de escrita

* `[Fact]` → teste único.
* `[Theory] + [InlineData]` → teste parametrizado.
* Nomeie métodos descrevendo comportamento esperado.
* Use helpers ou factories para reduzir duplicação de código nos testes.

---

## 🛠️ Tutorial Prático com xUnit e .NET 9

### 1️⃣ Criar projeto de teste

```bash
dotnet new console -n TestLegibilidade
cd TestLegibilidade
dotnet new xunit -n TestLegibilidade.Tests
dotnet add TestLegibilidade.Tests reference ../TestLegibilidade/TestLegibilidade.csproj
```

---

### 2️⃣ Testes frágeis vs. testes legíveis

#### Teste ruim (frágil e confuso):

```csharp
[Fact]
public void Test1()
{
    var account = new BankAccount("123", 100m);
    account.Deposit(50m);
    Assert.True(account.Balance == 150);
}
```

#### Teste refatorado (legível, AAA):

```csharp
[Fact]
public void Deposit_ShouldIncreaseBalance()
{
    // Arrange
    var account = new BankAccount("123", 100m);

    // Act
    account.Deposit(50m);

    // Assert
    Assert.Equal(150m, account.Balance);
}
```

---

### 3️⃣ Testes parametrizados com `[Theory]`

```csharp
[Theory]
[InlineData(50, 150)]
[InlineData(0, 100)]
[InlineData(200, 300)]
public void Deposit_ShouldWorkWithVariousAmounts(decimal deposit, decimal expectedBalance)
{
    var account = new BankAccount("123", 100m);
    account.Deposit(deposit);
    Assert.Equal(expectedBalance, account.Balance);
}
```

Permite **cobrir vários cenários positivos** sem duplicar código.

---

### 4️⃣ Refatorando testes negativos

```csharp
[Fact]
public void Withdraw_ShouldThrow_WhenSaldoInsuficiente()
{
    var account = new BankAccount("123", 100m);
    Assert.Throws<InvalidOperationException>(() => account.Withdraw(200m));
}
```

*Separando positivo/negativo, o teste fica claro e isolado.*

---

### 5️⃣ Evitando mocks excessivos

```csharp
// Má prática: mockando tudo
var mock = new Mock<INotificationService>();
mock.Setup(m => m.Notify(It.IsAny<string>()));
```

Prefira **testes de integração simples** ou mocks apenas para dependências externas **críticas**.

---

## 🛠️ Exercício Prático

1. Receba um **conjunto de testes ruins** para refatorar.
2. Separe **cenários positivos e negativos**.
3. Ajuste nomes e estrutura AAA.
4. Teste os novos testes no **dotnet test**.

Exemplo de exercício:

```csharp
[Fact]
public void Test2()
{
    var account = new BankAccount("321", 200m);
    account.Withdraw(50);
    Assert.True(account.Balance == 150);
}
```

Refatore seguindo boas práticas.

---

## 6️⃣ Integração Azure DevOps

Crie pipeline simples para rodar testes automaticamente:

```yaml
trigger:
- main

pool:
  vmImage: 'windows-latest'

steps:
- task: UseDotNet@2
  inputs:
    packageType: 'sdk'
    version: '9.x'

- task: DotNetCoreCLI@2
  inputs:
    command: 'restore'
    projects: '**/*.csproj'

- task: DotNetCoreCLI@2
  inputs:
    command: 'test'
    projects: '**/*.Tests/*.csproj'
```

*Assim todo commit dispara os testes, garantindo legibilidade e evitando regressões.*

---

## ⏱️ Tempo

* **2h** (aula prática e teórica):

  * 30 min — Teoria + exemplos guiados
  * 60 min — Exercícios práticos de refatoração
  * 30 min — Discussão e boas práticas, Q&A



----
**Mini-projeto completo em C#** para a **Sessão 4**, focado em **refatoração de testes ruins**, **cenários positivos e negativos**, **xUnit**, **Theory** e integração com **Azure DevOps**. 

---

# Mini-projeto C# – Testes Legíveis e Anti-patterns

## Estrutura do projeto

```
TestLegibilidade/
├─ TestLegibilidade/                 # Projeto principal
│  └─ BankAccount.cs
├─ TestLegibilidade.Tests/           # Projeto de testes xUnit
│  └─ BankAccountTests.cs
└─ TestLegibilidade.sln
```

```bash
dotnet new sln -n TestLegibilidade
dotnet new console -n TestLegibilidade
dotnet new xunit -n TestLegibilidade.Tests
dotnet sln add TestLegibilidade/ 
dotnet sln add TestLegibilidade.Tests/TestLegibilidade.Tests.csproj
dotnet add TestLegibilidade.Tests reference TestLegibilidade/
```

---

## 1️⃣ Projeto principal: BankAccount

### **BankAccount.cs**

```csharp
using System;

namespace TestLegibilidade
{
    public class BankAccount
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountNumber, decimal initialBalance)
        {
            if(initialBalance < 0) throw new ArgumentException("Saldo inicial não pode ser negativo.");
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Depósito deve ser positivo.");
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Saque deve ser positivo.");
            if (Balance - amount < 0) throw new InvalidOperationException("Saldo insuficiente.");
            Balance -= amount;
        }
    }
}
```

---

## 2️⃣ Projeto de testes: BankAccountTests

### **Testes ruins (intencionais)**

```csharp
using Xunit;

namespace TestLegibilidade.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void Test1()
        {
            var account = new BankAccount("123", 100m);
            account.Deposit(50);
            Assert.True(account.Balance == 150);
        }

        [Fact]
        public void Test2()
        {
            var account = new BankAccount("321", 200m);
            account.Withdraw(50);
            Assert.True(account.Balance == 150);
        }

        [Fact]
        public void Test3()
        {
            var account = new BankAccount("555", 100m);
            account.Withdraw(200);
        }
    }
}
```

> Estes testes têm nomes ruins, asserts confusos e falta de tratamento de exceção no último.


---

### **Testes refatorados (legíveis + AAA + Theory)**

```csharp
using Xunit;

namespace TestLegibilidade.Tests
{
    public class BankAccountTests
    {
        [Theory]
        [InlineData(50, 150)]
        [InlineData(0, 100)]
        [InlineData(200, 300)]
        public void Deposit_ShouldIncreaseBalance(decimal depositAmount, decimal expectedBalance)
        {
            // Arrange
            var account = new BankAccount("123", 100m);

            // Act
            account.Deposit(depositAmount);

            // Assert
            Assert.Equal(expectedBalance, account.Balance);
        }

        [Fact]
        public void Withdraw_ShouldDecreaseBalance_WhenSufficientFunds()
        {
            // Arrange
            var account = new BankAccount("321", 200m);

            // Act
            account.Withdraw(50m);

            // Assert
            Assert.Equal(150m, account.Balance);
        }

        [Fact]
        public void Withdraw_ShouldThrow_WhenSaldoInsuficiente()
        {
            // Arrange
            var account = new BankAccount("555", 100m);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(200m));
        }
    }
}
```

✅ Agora os testes estão **legíveis**, seguem **AAA**, têm **nomes descritivos** e cobrem **cenários positivos e negativos**.

---

## 3️⃣ Integração Azure DevOps

Crie `azure-pipelines.yml` na raiz do projeto:

```yaml
trigger:
- main

pool:
  vmImage: 'windows-latest'

variables:
  buildConfiguration: 'Release'

steps:
- task: UseDotNet@2
  inputs:
    packageType: 'sdk'
    version: '9.x'

- task: DotNetCoreCLI@2
  inputs:
    command: 'restore'
    projects: '**/*.csproj'

- task: DotNetCoreCLI@2
  inputs:
    command: 'build'
    projects: '**/*.csproj'
    arguments: '--configuration $(buildConfiguration)'

- task: DotNetCoreCLI@2
  inputs:
    command: 'test'
    projects: '**/*.Tests/*.csproj'
    arguments: '--configuration $(buildConfiguration)'
```

*Cada commit no `main` executará os testes automaticamente.*

---



## 4️⃣ Exercícios práticos para a aula

1. **Refatorar testes ruins** fornecidos no projeto inicial.
2. **Adicionar cenários negativos extras**, como depósitos negativos.
3. **Transformar asserts confusos em asserts claros**, usando `Assert.Equal` ou `Assert.Throws`.
4. **Criar testes parametrizados** com `[Theory]` para operações repetitivas.
5. (Bônus) Integrar uma **classe de Notificação** simulada e testar com mocks simples.



---
Moongy 2025 - Todos os direitos reservados