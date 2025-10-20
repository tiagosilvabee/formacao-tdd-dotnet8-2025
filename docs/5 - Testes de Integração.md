# 🔌 Sessão 5 — Testes de Integração (API e Banco de Dados)

## 🎯 Objetivos

* Entender as diferenças entre **testes de unidade** e **testes de integração**.
* Aprender a testar **controladores e endpoints reais**.
* Criar testes com **banco de dados em memória (SQLite)**.
* Executar testes de integração automaticamente via **Azure DevOps**.

---

## 📚 Material Teórico

### 1️⃣ Diferenças entre teste de unidade e integração

| Tipo           | O que testa                     | Dependências         | Velocidade    | Exemplo                             |
| -------------- | ------------------------------- | -------------------- | ------------- | ----------------------------------- |
| **Unidade**    | Lógica isolada (método, classe) | Nenhuma real         | ⚡ Rápido      | Testar `Deposit()` em `BankAccount` |
| **Integração** | Vários componentes juntos       | Banco, API, serviços | 🐢 Mais lento | Testar `/api/accounts` com SQLite   |

---

### 2️⃣ Quando usar testes de integração

Use testes de integração quando quiser **garantir que os componentes realmente funcionam juntos**, por exemplo:

* O repositório grava e lê do banco.
* O endpoint responde com os dados esperados.
* A pipeline valida que a aplicação está íntegra.

---

### 3️⃣ Boas práticas

* Use **bancos em memória** (SQLite) para evitar efeitos colaterais.
* Crie **dados de teste** antes de cada execução.
* Teste o **caminho completo**: requisição → API → banco → resposta.
* Mantenha os testes **independentes** (cada um cria seu próprio ambiente).

---

## 🧱 Mini-projeto C# – Testes de Integração com API e SQLite

### Estrutura do projeto

```
TestIntegracao/
├─ Api/                        # Projeto principal (Minimal API)
│  ├─ Program.cs
│  ├─ Data/
│  │   └─ AppDbContext.cs
│  └─ Models/
│      └─ Account.cs
├─ Api.Tests/                  # Projeto de testes de integração
│  └─ AccountApiTests.cs
├─ TestIntegracao.sln
└─ azure-pipelines.yml
```

---

### 1️⃣ Criar solução e projetos

```bash
dotnet new sln -n TestIntegracao
dotnet new web -n Api
dotnet new xunit -n Api.Tests
dotnet sln add Api/ Api.Tests/
dotnet add Api.Tests reference Api/
dotnet add Api package Microsoft.EntityFrameworkCore.Sqlite
dotnet add Api.Tests package Microsoft.AspNetCore.Mvc.Testing
dotnet add Api.Tests package Microsoft.EntityFrameworkCore.Sqlite
dotnet add Api.Tests package Microsoft.EntityFrameworkCore.InMemory
```

---

### 2️⃣ API com banco SQLite em memória

#### **AppDbContext.cs**

```csharp
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts => Set<Account>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
```

#### **Account.cs**

```csharp
namespace Api.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Owner { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}
```

#### **Program.cs**

```csharp
using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("DataSource=:memory:"));

var app = builder.Build();

// Inicializa banco em memória
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.OpenConnection();
    db.Database.EnsureCreated();
}

app.MapGet("/api/accounts", async (AppDbContext db) =>
    await db.Accounts.ToListAsync());

app.MapPost("/api/accounts", async (AppDbContext db, Account account) =>
{
    db.Accounts.Add(account);
    await db.SaveChangesAsync();
    return Results.Created($"/api/accounts/{account.Id}", account);
});

app.Run();

public partial class Program { } // Necessário para testes de integração
```

---

### 3️⃣ Testes de Integração com xUnit + WebApplicationFactory

#### **AccountApiTests.cs**

```csharp
using System.Net;
using System.Net.Http.Json;
using Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Api.Tests
{
    public class AccountApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AccountApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostAccount_ShouldCreateAccount()
        {
            // Arrange
            var newAccount = new Account { Owner = "Maria", Balance = 500 };

            // Act
            var response = await _client.PostAsJsonAsync("/api/accounts", newAccount);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var created = await response.Content.ReadFromJsonAsync<Account>();
            Assert.NotNull(created);
            Assert.Equal("Maria", created!.Owner);
            Assert.Equal(500, created.Balance);
        }

        [Fact]
        public async Task GetAccounts_ShouldReturnList()
        {
            // Act
            var response = await _client.GetAsync("/api/accounts");

            // Assert
            response.EnsureSuccessStatusCode();
            var accounts = await response.Content.ReadFromJsonAsync<List<Account>>();
            Assert.NotNull(accounts);
        }
    }
}
```

✅ Testes reais que **sobem a API**, **criam o banco em memória**, e **fazem chamadas HTTP**.

---

## ⚙️ Integração Azure DevOps

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
  displayName: 'Instalar .NET 9 SDK'
  inputs:
    packageType: 'sdk'
    version: '9.x'

- task: DotNetCoreCLI@2
  displayName: 'Restaurar dependências'
  inputs:
    command: 'restore'
    projects: '**/*.csproj'

- task: DotNetCoreCLI@2
  displayName: 'Compilar solução'
  inputs:
    command: 'build'
    projects: '**/*.csproj'
    arguments: '--configuration $(buildConfiguration)'

- task: DotNetCoreCLI@2
  displayName: 'Executar testes de integração'
  inputs:
    command: 'test'
    projects: '**/*.Tests/*.csproj'
    arguments: '--configuration $(buildConfiguration)'
```

*Cada commit dispara os testes de integração, garantindo que API + banco funcionem juntos.*

---

## 🧪 Exercícios Práticos

1. **Adicionar endpoint `GET /api/accounts/{id}`** e criar teste correspondente.
2. **Criar cenário negativo** — tentar criar conta com saldo negativo (deve falhar).
3. **Testar integração completa**: `POST` cria conta → `GET` retorna conta criada.
4. (Bônus) Adicionar `PUT` para atualizar saldo e testar.
5. Validar cobertura no Azure DevOps.

---

## Exemplos com MOQ

* ✅ **Testes de integração** — com banco **SQLite em memória**, endpoints reais e contexto de dados.
* 🧪 **Testes unitários com Moq** — isolando dependências, simulando repositórios e serviços.

---

### 🧱 Estrutura final do projeto

```
TestIntegracao_Sessao5/
│
├── src/
│   ├── MinimalApiApp/
│   │   ├── Program.cs
│   │   ├── Models/
│   │   │   └── Product.cs
│   │   ├── Data/
│   │   │   └── AppDbContext.cs
│   │   ├── Services/
│   │   │   └── ProductService.cs
│   │   └── Repositories/
│   │       ├── IProductRepository.cs
│   │       └── ProductRepository.cs
│
├── tests/
│   ├── MinimalApiApp.Tests.Integration/
│   │   └── ProductIntegrationTests.cs
│   └── MinimalApiApp.Tests.Unit/
│       └── ProductServiceTests.cs   👈 com Moq
│
└── .github/workflows/
    └── dotnet-build-test.yml
```

---

### 🧩 Exemplo: `ProductService.cs`

```csharp
using MinimalApiApp.Models;
using MinimalApiApp.Repositories;

namespace MinimalApiApp.Services;

public class ProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Product>> GetAllAsync() => await _repo.GetAllAsync();

    public async Task<Product?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

    public async Task<Product> CreateAsync(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("Nome do produto é obrigatório");

        return await _repo.AddAsync(product);
    }
}
```

---

### 🧪 Exemplo: Teste com **Moq** → `ProductServiceTests.cs`

```csharp
using MinimalApiApp.Models;
using MinimalApiApp.Repositories;
using MinimalApiApp.Services;
using Moq;

namespace MinimalApiApp.Tests.Unit;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _mockRepo;
    private readonly ProductService _service;

    public ProductServiceTests()
    {
        _mockRepo = new Mock<IProductRepository>();
        _service = new ProductService(_mockRepo.Object);
    }

    [Fact]
    public async Task CreateAsync_DeveLancarExcecao_QuandoNomeForVazio()
    {
        var product = new Product { Name = "" };
        await Assert.ThrowsAsync<ArgumentException>(() => _service.CreateAsync(product));
    }

    [Fact]
    public async Task CreateAsync_DeveChamarAddAsync_UmaVez()
    {
        var product = new Product { Name = "Teclado" };
        _mockRepo.Setup(r => r.AddAsync(It.IsAny<Product>())).ReturnsAsync(product);

        var result = await _service.CreateAsync(product);

        _mockRepo.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
        Assert.Equal("Teclado", result.Name);
    }

    [Fact]
    public async Task GetAllAsync_DeveRetornarListaDeProdutos()
    {
        var produtos = new List<Product> { new() { Id = 1, Name = "Mouse" } };
        _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(produtos);

        var result = await _service.GetAllAsync();

        Assert.Single(result);
        Assert.Equal("Mouse", result.First().Name);
    }
}
```


---


## ⏱️ Tempo

* **2h30 (aula prática e teórica):**

  * 30 min — Conceitos de integração + setup de API
  * 60 min — Desenvolvimento e testes
  * 30 min — Execução em pipeline e Q&A
  * 30 min — Exercício guiado extra (GET by ID ou PUT)

---

## 💬 Fechamento

> **Testes de integração são a ponte entre código e realidade.**
> Eles garantem que tudo funcione junto — como na vida real.
> Enquanto os testes unitários dizem “minha parte está certa”, os de integração perguntam “e se juntarmos tudo, ainda funciona?” 💡

---

## Referências

https://learn.microsoft.com/pt-br/shows/visual-studio-toolbox/unit-testing-moq-framework
https://www.codemag.com/Article/2305041/Using-Moq-A-Simple-Guide-to-Mocking-for-.NET
https://github.com/devlooped/moq

---
Moongy 2025 - Todos os direitos reservados