
# 🧮 GitHub Actions CI + SonarCloud (.NET 9)

![Build](https://github.com/seu-org/github-actions-ci/actions/workflows/ci.yml/badge.svg)
![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=seu-org_github-actions-ci&metric=alert_status)

Projeto exemplo de integração contínua com análise de qualidade via **SonarCloud** e cobertura de testes automatizada.

## 🚀 Tecnologias
- .NET 9
- xUnit
- GitHub Actions
- SonarCloud

## ⚙️ Executar localmente

```bash
dotnet restore
dotnet build
dotnet test --collect:"XPlat Code Coverage"
```
