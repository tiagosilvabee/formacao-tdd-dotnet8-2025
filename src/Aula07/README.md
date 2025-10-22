# 📊 SonarCloud CI Sample (.NET 9 + GitHub Actions)

Este repositório demonstra um pipeline de integração contínua completo com **SonarCloud**, **.NET 9** e **GitHub Actions**.

---

## 🧩 Objetivos

* Build e testes automatizados.
* Análise de qualidade e cobertura de código no SonarCloud.
* Exibição dos *badges* de qualidade diretamente no README.

---

## 🚀 CI Status

![Build](https://github.com/tiagosilvabee/formacao-tdd-dotnet8-2025/actions/workflows/ci.yml/badge.svg)
![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=tiagosilvabee_formacao-tdd-dotnet8-2025&metric=alert_status)

> 🧩 Substitua `seu-org` e `github-actions-ci` pelos valores reais da sua conta no SonarCloud e repositório no GitHub.

---

## 💡 Proposta Prática

1. Configure o **SonarCloud** e adicione os *secrets* `SONAR_TOKEN` e `SONAR_HOST_URL` no GitHub.
2. Execute o pipeline completo (build + testes + análise SonarCloud).
3. Corrija pelo menos **1 problema real** reportado (duplicação, *code smell* ou complexidade).
4. Reexecute o pipeline e verifique a melhoria na *Quality Gate*.
5. Atualize este README com um breve comentário sobre a evolução da qualidade.

---

## 🧱 Estrutura do Projeto

```
.github/workflows/ci.yml  → Pipeline CI com análise SonarCloud
src/SampleApp/            → Aplicação exemplo (.NET 9)
tests/SampleApp.Tests/    → Testes unitários com cobertura
```

---

## 🧩 Execução local

```bash
dotnet build
dotnet test --collect:"XPlat Code Coverage"
```

---

## 🪶 Resultado Esperado

Ao final, o aluno terá:

* Workflow CI completo (.NET 9 + SonarCloud).
* Dashboard público no SonarCloud.
* Badges de *Build* e *Quality Gate* no README.
