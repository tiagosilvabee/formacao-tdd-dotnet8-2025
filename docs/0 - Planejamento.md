## 🗂️ **Planejamento das 8 Sessões – Formação TDD com .NET 8**

### **🧠 Sessão 1 — Fundamentos de Testes de Unidade e TDD**

**Objetivos:**

* Apresentar o conceito de testes automatizados e sua importância.
* Entender o ciclo TDD: Red → Green → Refactor.
* Introduzir práticas de Baby Steps no desenvolvimento.

**Atividades:**

* Discussão teórica e exemplos práticos.
* Kata FizzBuzz guiado com TDD.

---

### **🛠️ Sessão 2 — Configuração do Ambiente (.NET 8, xUnit, FluentAssertions)**

**Objetivos:**

* Configurar o ambiente de desenvolvimento.
* Criar o primeiro projeto de testes com xUnit e FluentAssertions.
* Explorar a estrutura básica de um teste automatizado.

**Atividades:**

* Hands-on: criação de projeto `src/` + `tests/`
* Testes simples com métodos matemáticos (ex: calculadora)

---

### **🧱 Sessão 3 — Design Orientado a Testes**

**Tópicos:**

* Princípios de design: SRP, coesão, encapsulamento, acoplamento.
* Como TDD influencia e melhora o design do sistema.

**Atividades:**

* Análise e refatoração de código mal projetado.
* Implementação orientada a testes de uma classe com múltiplas responsabilidades.
* Início de um domínio exemplo (ex: sistema de pedidos ou carrinho de compras).

---

### **🧼 Sessão 4 — Escrevendo Testes Legíveis e Evitando Anti-patterns**

**Tópicos:**

* Boas práticas na escrita de testes: nome de testes, estrutura AAA (Arrange-Act-Assert), granularidade.
* Anti-patterns comuns: testes frágeis, mocks excessivos, over-testing, etc.

**Atividades:**

* Refatoração de testes ruins.
* Exercício orientado: cobertura de cenários positivos e negativos com clareza.

---

### **🔌 Sessão 5 — Testes de Integração (API e Banco de Dados)**

**Tópicos:**

* Diferenças entre teste de unidade e de integração.
* Como testar controladores e serviços com dependências reais ou mockadas.

**Atividades:**

* Criar testes de integração com um banco em memória (SQLite ou TestContainer).
* Testar endpoints REST simples (GET/POST).

---

### **⚙️ Sessão 6 — Automação de Testes com GitHub Actions**

**Tópicos:**

* Introdução ao GitHub Actions.
* Criação de workflow para execução de testes automáticos.

**Atividades:**

* Criar `.github/workflows/ci.yml`
* Validar testes em cada push/pull request.
* Adicionar badge de status no README.

---

### **📊 Sessão 7 — Análise de Cobertura e Qualidade com SonarQube**

**Tópicos:**

* Instalar/configurar o Sonar Scanner para .NET.
* Integração do SonarQube no CI via GitHub Actions.
* Interpretação de métricas: cobertura, complexidade, duplicação, code smells.

**Atividades:**

* Executar análise do projeto e interpretar resultados no dashboard do SonarQube.
* Resolver ao menos 1 alerta real.

---

### **🚀 Sessão 8 — Projeto Final + Integração Contínua**

**Tópicos:**

* Consolidar o aprendizado com um projeto de domínio completo.
* Discutir os trade-offs do uso de TDD em diferentes contextos.

**Atividades:**

* Projeto: construir pequeno sistema (ex: API de tarefas, controle financeiro).
* Testar, integrar e automatizar com CI/CD.
* Rodar pipeline, avaliar cobertura e realizar demo final.
