# ⚙️ Sessão 6 — Integração Contínua com **GitHub Actions**

## 🎯 Objetivos

* Entender como o **GitHub Actions** automatiza a execução de testes.
* Criar um **workflow CI** que roda a cada *push* e *pull request*.
* Adicionar um **badge de status** no `README.md`.
* Garantir qualidade e estabilidade do código através de pipelines automatizados.

---

## 📚 Material Teórico

### 1️⃣ O que é GitHub Actions

**GitHub Actions** é o serviço de automação do GitHub que permite executar tarefas — como *build*, *test* e *deploy* — diretamente a partir de eventos do repositório (push, PR, release etc).

🔁 **Eventos comuns:**

* `push`: a cada commit em uma branch.
* `pull_request`: quando um PR é aberto ou atualizado.
* `workflow_dispatch`: execução manual.

⚙️ **Execução em runners hospedados** (Linux, Windows ou macOS).

---

### 2️⃣ Conceito de Workflow

Um **workflow** é definido por um arquivo YAML dentro de `.github/workflows`.

| Elemento  | Descrição                             |
| --------- | ------------------------------------- |
| `name`    | Nome do workflow (exibido no GitHub). |
| `on`      | Eventos que disparam o workflow.      |
| `jobs`    | Tarefas que serão executadas.         |
| `runs-on` | Sistema operacional do runner.        |
| `steps`   | Sequência de comandos e ações.        |

---

### 3️⃣ Estrutura básica

```yaml
name: CI

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - name: Checkout do código
        uses: actions/checkout@v4

      - name: Instalar .NET
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '9.x'

      - name: Restaurar dependências
        run: dotnet restore

      - name: Compilar projeto
        run: dotnet build --configuration Release --no-restore

      - name: Executar testes
        run: dotnet test --configuration Release --no-build --verbosity normal
```

📂 **Localização:** `.github/workflows/ci.yml`

---

## 🧱 Mini-projeto — Pipeline CI com Testes Automáticos

### Estrutura do repositório

```
github-actions-ci/
│
├── src/
│   └── Api/
│       ├── Program.cs
│       └── Api.csproj
│
├── tests/
│   └── Api.Tests/
│       ├── Api.Tests.csproj
│       └── SimpleTests.cs
│
├── .github/
│   └── workflows/
│       └── ci.yml
│
└── README.md
```

---

### 1️⃣ Criar solução e projetos

```bash
dotnet new sln -n GithubActionsCI
dotnet new web -n Api
dotnet new xunit -n Api.Tests
dotnet sln add Api/ Api.Tests/
dotnet add Api.Tests reference Api/
```

---

### 2️⃣ Teste simples de exemplo — `SimpleTests.cs`

```csharp
namespace Api.Tests;

public class SimpleTests
{
    [Fact]
    public void Soma_DeveRetornarResultadoCorreto()
    {
        var resultado = 2 + 3;
        Assert.Equal(5, resultado);
    }
}
```

---

### 3️⃣ Workflow `.github/workflows/ci.yml`

```yaml
name: .NET CI

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
      - name: Checkout do código
        uses: actions/checkout@v4

      - name: Instalar .NET 9
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '9.x'

      - name: Restaurar dependências
        run: dotnet restore

      - name: Compilar projeto
        run: dotnet build --configuration Release --no-restore

      - name: Executar testes
        run: dotnet test --configuration Release --no-build --verbosity normal
```

🧪 **Resultado esperado:**

* Cada *push* e *pull request* dispara o workflow.
* O status aparece no repositório (✅ ou ❌).

---

### 4️⃣ Adicionar badge de status ao `README.md`

```markdown
# Github Actions CI

![.NET CI](https://github.com/<USUARIO>/<REPO>/actions/workflows/ci.yml/badge.svg)

Este projeto demonstra um pipeline básico de CI com GitHub Actions, executando testes automatizados em cada push ou PR.
```

> 💡 Dica: substitua `<USUARIO>` e `<REPO>` pelo nome do seu repositório GitHub.

---

## 💬 Boas Práticas

* **Nomeie workflows claramente**: `ci.yml`, `deploy.yml`, etc.
* **Use `matrix`** para testar múltiplas versões do .NET.
* **Evite segredos expostos** — use `secrets.GITHUB_TOKEN`.
* **Adicione badges** para visibilidade do estado do build.
* **Automatize sempre que possível.**

---

## 🧪 Exercícios Práticos

1. Criar o arquivo `.github/workflows/ci.yml` conforme o exemplo.
2. Executar um `git push` e verificar o status no **Actions**.
3. Alterar o teste para falhar e observar o resultado ❌.
4. Corrigir e confirmar o novo status ✅.
5. Adicionar o **badge de build** no README.
6. (Bônus) Adicionar um *job* adicional para **verificar cobertura de testes** usando `dotnet test --collect:"XPlat Code Coverage"`.

---

## ⏱️ Tempo

* **2h00 (aula prática e teórica):**

  * 30 min — Introdução ao GitHub Actions.
  * 60 min — Criação e execução do workflow CI.
  * 30 min — Exercícios e integração com README.

---

## 💬 Fechamento

> “Automatizar é libertar o desenvolvedor da repetição.
> Cada commit testado é um passo rumo à confiança no código.” 💡


---

🔹 Nome: **`github-actions-ci`**
🔹 Stack: **.NET 9 (Minimal API + xUnit)**
🔹 Inclui: **workflow GitHub Actions** + **badge já configurado no README** (com link editável).

Aqui está o conteúdo completo que você pode subir direto no GitHub (ou eu posso empacotar em `.zip` se quiser):

---

## 📦 Estrutura final do repositório

```
github-actions-ci/
│
├── src/
│   └── Api/
│       ├── Program.cs
│       └── Api.csproj
│
├── tests/
│   └── Api.Tests/
│       ├── SimpleTests.cs
│       └── Api.Tests.csproj
│
├── .github/
│   └── workflows/
│       └── ci.yml
│
└── README.md
```

---

### 🧩 **src/Api/Program.cs**

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello from GitHub Actions CI 👋");

app.Run();
```

---

### ⚙️ **.github/workflows/ci.yml**

```yaml
name: .NET CI

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
      - name: Checkout do código
        uses: actions/checkout@v4

      - name: Instalar .NET 9
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '9.x'

      - name: Restaurar dependências
        run: dotnet restore

      - name: Compilar projeto
        run: dotnet build --configuration Release --no-restore

      - name: Executar testes
        run: dotnet test --configuration Release --no-build --verbosity normal
```

---

### 🧪 **tests/Api.Tests/SimpleTests.cs**

```csharp
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
        // Simula apenas um teste placeholder
        var mensagem = "Hello from GitHub Actions CI 👋";
        Assert.Contains("GitHub Actions", mensagem);
    }
}
```

---

### 📝 **README.md**

```markdown
# 🚀 GitHub Actions CI

![.NET CI](https://github.com/<USUARIO>/<REPO>/actions/workflows/ci.yml/badge.svg)

Pipeline básico de **Integração Contínua (CI)** usando **GitHub Actions** e **.NET 9**.  
A cada *push* ou *pull request* na branch `main`, o workflow executa os testes automaticamente.

---

## 🧱 Estrutura

```

src/Api/          → Projeto principal (Minimal API)
tests/Api.Tests/  → Testes automatizados com xUnit
.github/workflows → Pipeline CI

````

---

## ⚙️ Executar localmente

```bash
dotnet restore
dotnet build
dotnet test
````

---

## 💡 Workflow CI

Arquivo: `.github/workflows/ci.yml`

```yaml
on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]
```

> 💬 Substitua `<USUARIO>` e `<REPO>` na URL do badge pelo seu nome de usuário e repositório GitHub.


---

**Moongy 2025 - Todos os direitos reservados**
