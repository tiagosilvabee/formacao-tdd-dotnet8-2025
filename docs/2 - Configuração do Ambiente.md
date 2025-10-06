# **Sessão 2 — Configuração do Ambiente (.NET 9, xUnit, FluentAssertions)**

## 🎯 Objetivos

* Preparar o ambiente de desenvolvimento para TDD com .NET 9.
* Configurar e entender o xUnit como framework de testes.
* Introduzir o FluentAssertions para assertivas mais legíveis e expressivas.
* Validar a configuração criando o primeiro teste simples.
* Criar e rodar testes localmente.
* Integrar testes em Azure DevOps Pipelines.
* Entender como TDD se conecta a CI/CD.

---

## 📚 Material Teórico

### 1. .NET 9, xUnit e FluentAssertions

* Explicação rápida sobre o .NET 9: plataforma, compatibilidade e novidades.
* Diferença entre SDK e Runtime.
* Comandos básicos: `dotnet --version`, `dotnet new console`, `dotnet new classlib`.

### 2. xUnit

* O que é o xUnit e por que é usado em TDD.
* Comparação rápida com outros frameworks de teste (MSTest, NUnit).

| **Característica**        | **xUnit**                                            | **MSTest**                                          | **NUnit**                                                        |
| ------------------------- | ---------------------------------------------------- | --------------------------------------------------- | ---------------------------------------------------------------- |
| **Criador / Suporte**     | Microsoft, voltado para .NET Core/5+                 | Microsoft, tradicional no .NET                      | Comunidade, suporte amplo                                        |
| **Popularidade**          | Muito usado em projetos modernos (.NET Core/5+)      | Usado em projetos legados e corporativos            | Popular, mas menos em .NET Core                                  |
| **Atributos de Teste**    | `[Fact]` (teste simples), `[Theory]` (parametrizado) | `[TestMethod]`, `[TestClass]`                       | `[Test]`, `[TestFixture]`                                        |
| **Testes Parametrizados** | `[Theory]` + `[InlineData]`                          | `[DataTestMethod]` + `[DataRow]`                    | `[TestCase]`                                                     |
| **Setup / Teardown**      | Construtor para setup, `IDisposable` para teardown   | `[TestInitialize]` / `[TestCleanup]`                | `[SetUp]` / `[TearDown]`                                         |
| **Assertiva**             | Fluent, geralmente combinado com FluentAssertions    | Tradicional: `Assert.AreEqual()`, `Assert.IsTrue()` | Tradicional, também suporta FluentAssertions                     |
| **Integração com CI/CD**  | Excelente, projetado para .NET Core/CI moderno       | Boa, mas mais legado                                | Boa, mas precisa de adaptadores                                  |
| **Execução paralela**     | Suporte nativo a paralelismo                         | Limitado                                            | Suporte a paralelismo configurável                               |
| **Facilidade de uso**     | Mais moderna, leve, fácil para TDD                   | Tradicional, pode ser verbosa                       | Equilibrada, flexível, boa documentação                          |
| **Melhor cenário de uso** | Projetos novos, TDD, .NET Core/5+                    | Projetos legados, integração MS                     | Projetos que precisam de flexibilidade e parametrização avançada |


💡 **Dica:** Para TDD moderno com .NET 9, o **xUnit** é geralmente a escolha mais natural, especialmente combinado com **FluentAssertions**, porque deixa os testes mais legíveis e o ciclo Red → Green → Refactor mais fluido.

* Estrutura de um teste xUnit:

  ```csharp
  public class CalculatorTests
  {
      [Fact]
      public void Sum_ShouldReturnCorrectValue()
      {
          var calculator = new Calculator();
          var result = calculator.Sum(2, 3);
          Assert.Equal(5, result);
      }
  }
  ```

### 3. FluentAssertions

* Conceito: tornar os asserts mais legíveis e expressivos.
* Exemplos de uso:

  ```csharp
  result.Should().Be(5);
  list.Should().Contain(3);
  action.Should().Throw<InvalidOperationException>();
  ```

---

## ⚙️ Configuração do Ambiente (Passo a Passo)

1. **Instalar o .NET 9 SDK**

   * Baixar em [dotnet.microsoft.com](https://dotnet.microsoft.com/)
   * Verificar instalação: `dotnet --version`

2. **Criar a solução e projetos**

   ```bash
   dotnet new sln -n TDDExample
   dotnet new classlib -n Calculator
   dotnet new xunit -n Calculator.Tests
   dotnet sln add Calculator/Calculator.csproj
   dotnet sln add Calculator.Tests/Calculator.Tests.csproj
   dotnet add Calculator.Tests/Calculator.Tests.csproj reference Calculator/Calculator.csproj
   ```

3. **Adicionar FluentAssertions**

   ```bash
   dotnet add Calculator.Tests/Calculator.Tests.csproj package FluentAssertions
   ```

4. **Testar execução dos testes**

   ```bash
   dotnet test
   ```

---

## 💡 Prática: Primeiro teste com TDD

1. Criar uma classe `Calculator` com método `Sum(int a, int b)` (sem implementação ainda).
2. Criar teste `Sum_ShouldReturnCorrectValue` no projeto de testes.
3. Seguir o ciclo TDD: **Red → Green → Refactor**.

Exemplo inicial de teste com FluentAssertions:

```csharp
[Fact]
public void Sum_ShouldReturnCorrectValue()
{
    var calculator = new Calculator();
    var result = calculator.Sum(2, 3);
    result.Should().Be(5);
}
```

3. **Azure DevOps**

   * Conceito: repositórios, pipelines, artefatos.
   * Como CI/CD automatiza testes e garante qualidade.
   * Como criar um pipeline simples que roda testes xUnit.

---

## ⚙️ Configuração do Ambiente (Passo a Passo)

1. Instalar .NET 9 SDK, criar solução e projetos xUnit + FluentAssertions (igual antes).
2. Rodar teste localmente (`dotnet test`).
3. Criar **repositório no Azure DevOps**:

   * `New Project` → Git repo → push do projeto.
4. Configurar **Pipeline YAML** básico:

```yaml
trigger:
- main

pool:
  vmImage: 'windows-latest'

steps:
- task: UseDotNet@2
  inputs:
    packageType: 'sdk'
    version: '9.x.x'

- script: dotnet restore
  displayName: 'Restore packages'

- script: dotnet build --no-restore
  displayName: 'Build project'

- script: dotnet test --no-build --verbosity normal
  displayName: 'Run unit tests'
```

5. Validar execução dos testes no pipeline.

---

## 💡 Prática Guiada

* Criar uma **classe `Calculator`** e método `Sum` (sem implementação).
* Criar teste `Sum_ShouldReturnCorrectValue` usando FluentAssertions.
* Rodar teste local → pipeline Azure DevOps → ver teste passar automaticamente.
* Discutir como o ciclo **Red → Green → Refactor** agora se estende para CI/CD.

---

## 📝 Técnicas e Instrumentos de Avaliação

* Exercício: configurar projeto local + push no DevOps + pipeline que roda testes.
* Avaliar se todos conseguem ver **status do teste no Azure DevOps**.
* Discussão: benefícios de automatizar testes via pipeline.

---

## ⏱️ Tempo Estimado

* 30 min — Teoria: .NET 9, xUnit, FluentAssertions
* 45 min — Configuração local + testes iniciais
* 45 min — Azure DevOps: repositório + pipeline + execução de testes
* 15 min — Revisão e dúvidas


---
Moongy 2025 - Todos os direitos reservados