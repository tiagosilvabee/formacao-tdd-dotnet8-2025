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
```

---

## ⚙️ Executar localmente

```bash
dotnet restore
dotnet build
dotnet test
```

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

Moongy 2025 - Todos os direitos reservados.
