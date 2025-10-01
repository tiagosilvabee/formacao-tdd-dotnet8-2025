# Formação: Desenvolvimento Orientado por Testes (TDD) com .NET 9

![.NET](https://img.shields.io/badge/.NET-9-512BD4?style=flat&logo=dotnet)
![GitHub Actions](https://img.shields.io/badge/CI/CD-GitHub%20Actions-2088FF?style=flat&logo=githubactions)
![SonarQube](https://img.shields.io/badge/Quality-SonarQube-4E9BCD?style=flat&logo=sonarqube)
![License](https://img.shields.io/badge/license-MIT-blue.svg)

---

## 📖 Sobre o Projeto

Este repositório reúne os materiais, exemplos e exercícios práticos da formação **Desenvolvimento Orientado por Testes (TDD)** aplicada a projetos em **.NET 9**. O foco está no ciclo Red-Green-Refactor, testes de unidade, testes de integração, design orientado a testes, automação com GitHub Actions e análise de qualidade com SonarQube.

O objetivo é capacitar desenvolvedores a escrever código mais confiável, testável e com qualidade consistente, aplicando boas práticas do TDD.

---

## 📚 Conteúdos Abordados



0. [Planejamento](/docs/0%20-%20Planejamento.md)
1. [Fundamentos de testes de unidade e TDD](/docs/1%20-%20Fundamentos%20de%20testes%20de%20unidade%20e%20TDD.md)  
2. [Configuração do ambiente (.NET 9, xUnit, FluentAssertions)](/docs/2%20-%20Configuração%20do%20Ambiente.md) 
3. [Design orientado a testes: coesão, responsabilidade única, encapsulamento e acoplamento](/docs/3%20-%20Design%20Orientado%20a%20Testes.md)  
4. [Escrevendo testes legíveis e evitando anti-patterns](/docs/4%20-%20Escrevendo%20Testes%20Legíveis%20e%20Evitando%20Anti-patterns.md)  
5. [Testes de integração (API e banco de dados)](/docs/5%20-%20Testes%20de%20Integração.md)  
6. [Automação de testes com GitHub Actions](/docs/6%20-%20Automação%20de%20Testes%20com%20GitHub%20Actions.md)  
7. [Análise de cobertura e qualidade com SonarCloud](/docs/7%20-%20Análise%20de%20Cobertura%20e%20Qualidade%20com%20SonarQube.md)  
8. [Projeto final com integração contínua e entrega contínua (CI/CD)](/docs/8%20-%20Projeto%20Final%20+%20Integração%20Contínua.md)  

---

## 🛠️ Tecnologias e Ferramentas

- [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)  
- [xUnit](https://xunit.net/) — Framework de testes unitários  
- [FluentAssertions](https://fluentassertions.com/) — Biblioteca para assertivas legíveis  
- [GitHub Actions](https://github.com/features/actions) — Pipelines CI/CD  
- [SonarQube](https://www.sonarqube.org/) — Análise contínua de qualidade e cobertura  
- [VS Code / Visual Studio](https://code.visualstudio.com/)  

---

## 📁 Estrutura do Repositório

```plaintext
├── src/                   # Código-fonte dos exemplos e projeto final
    ├── Aula ##
        ├── .Application/  # Código-fonte da aplicação 
        ├── .tests/        # Projetos de testes unitários e integração
├── .github/workflows/     # Configurações dos pipelines do GitHub Actions
├── docs/                  # Materiais de apoio (slides, planos de aula)
└── README.md              # Documentação do projeto
```