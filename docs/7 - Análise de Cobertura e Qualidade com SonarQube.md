# 📊 Sessão 7 — Análise de Cobertura e Qualidade com SonarCloud

## 🎯 Objetivos

* Entender como o **SonarCloud** avalia a qualidade do código-fonte.
* Configurar o **SonarScanner for .NET** e integrá-lo ao **GitHub Actions**.
* Interpretar métricas de **coverage**, **complexidade**, **duplicação** e **code smells**.
* Resolver um alerta real com base na análise.

---

## 📚 Material Teórico

### ☁️ O que é o SonarCloud?

O **SonarCloud** é a versão SaaS do SonarQube — hospedada pela SonarSource — e totalmente integrada ao GitHub.
Ele fornece:

* **Code Smells**, **Bugs** e **Vulnerabilidades**
* **Cobertura de testes**
* **Duplicações e complexidade**
* **Quality Gates** para impedir merges com baixa qualidade

---

### ⚙️ Integração com o GitHub

1. **Crie uma conta no [SonarCloud](https://sonarcloud.io/)** e conecte via GitHub.
2. **Importe seu repositório** (ex: `github-actions-ci`).
3. **Obtenha o “Project Key”** — algo como `seu-org_github-actions-ci`.
4. Vá em **My Account > Security** e gere um **token** (ex: `SONAR_TOKEN`).
5. No GitHub, adicione os secrets:

   * `SONAR_TOKEN`
   * `SONAR_HOST_URL` → `https://sonarcloud.io`

---

### 🧩 Configurando o CI no GitHub Actions

Edite `.github/workflows/ci.yml` para incluir o **SonarCloud Scan**:

```yaml
name: CI

on:
  push:
    branches: [ "main" ]
  pull_request:
    branches: [ "main" ]

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
      - uses: actions/checkout@v4
        with:
          fetch-depth: 0

      - name: Setup .NET
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: 9.0.x

      - name: Restore dependencies
        run: dotnet restore

      - name: Build
        run: dotnet build --no-restore --configuration Release

      - name: Test with coverage
        run: dotnet test --collect:"XPlat Code Coverage" --results-directory ./coverage

      - name: SonarCloud Scan
        env:
          GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}
          SONAR_TOKEN: ${{ secrets.SONAR_TOKEN }}
        run: |
          dotnet tool install --global dotnet-sonarscanner
          dotnet sonarscanner begin /k:"seu-org_github-actions-ci" /o:"seu-org" /d:sonar.token="${{ secrets.SONAR_TOKEN }}" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.cs.vscoveragexml.reportsPaths=**/coverage.cobertura.xml
          dotnet build --no-incremental
          dotnet sonarscanner end /d:sonar.token="${{ secrets.SONAR_TOKEN }}"
```

> 🧩 Substitua `seu-org` e `seu-org_github-actions-ci` pelos valores reais da sua conta no SonarCloud.

---

### 📊 Interpretação de Métricas

| **Métrica**      | **Descrição**                            | **Ação Recomendada**                  |
| ---------------- | ---------------------------------------- | ------------------------------------- |
| **Coverage**     | Percentual de código coberto por testes. | Aumente a cobertura com novos testes. |
| **Complexity**   | Mede caminhos lógicos.                   | Simplifique métodos grandes.          |
| **Duplications** | Linhas duplicadas.                       | Refatore código repetido.             |
| **Code Smells**  | Más práticas de design.                  | Corrija progressivamente.             |

---

## 🧠 Atividades

1. **Executar o pipeline** e aguardar o upload para o SonarCloud.
2. **Abrir o dashboard** e interpretar as métricas do projeto.
3. **Corrigir ao menos 1 alerta real** (ex: duplicação, método longo, variável não usada).
4. **Reexecutar o pipeline** e confirmar a melhoria na *Quality Gate*.

---

### 🪶 Badge de Status no `README.md`

Adicione o badge de qualidade no seu `README.md` (troque `seu-org` e `github-actions-ci` pelos reais):

```markdown
![Build](https://github.com/seu-org/github-actions-ci/actions/workflows/ci.yml/badge.svg)
![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=seu-org_github-actions-ci&metric=alert_status)
```

---

## 🧩 Resultado Esperado

Ao final da sessão, o repositório terá:

* Workflow CI completo (.NET 9 + testes + cobertura + SonarCloud).
* Badge de *Build* e *Quality Gate* no README.
* Dashboard público no SonarCloud mostrando a qualidade do código.


---
Moongy 2025 - Todos os direitos reservados