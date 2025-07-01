# Sessão 1 — Fundamentos de Testes de Unidade e TDD

## 🎯 Objetivos

- Apresentar o conceito de testes automatizados e sua importância.  
- Entender o ciclo TDD: Red → Green → Refactor.  
- Introduzir práticas de Baby Steps no desenvolvimento.

---

## 📚 Material Teórico

### O que são testes automatizados?

Testes automatizados são scripts que validam o comportamento do código. Eles ajudam a garantir que as funcionalidades se comportem como esperado e evitam regressões em futuras alterações.

### Benefícios dos testes automatizados:

- Detectam erros precocemente  
- Permitem refatoração segura  
- Melhoram a qualidade e confiabilidade do software  
- Aumentam a confiança no processo de entrega contínua

### O ciclo do TDD: Red → Green → Refactor

- **Red**: Escrever um teste que falha (função ainda não implementada)  
- **Green**: Escrever o código mínimo para passar o teste  
- **Refactor**: Refatorar o código mantendo o teste passando

### Baby Steps

A ideia central é progredir com pequenas alterações no código e testar constantemente. Isso favorece um ritmo sustentável, minimiza erros e permite foco no design do sistema.

---

## 💻 Exemplo Prático - Kata FizzBuzz com TDD

### Problema:

Escreva uma função `FizzBuzz(int n)` que retorna:

- `"Fizz"` se `n` for múltiplo de 3  
- `"Buzz"` se `n` for múltiplo de 5  
- `"FizzBuzz"` se `n` for múltiplo de 3 e 5  
- O número como string caso contrário

### Passos no TDD:

1. Escrever teste para `n = 1` → espera `"1"`  
2. Escrever código mínimo para passar  
3. Teste para `n = 3` → espera `"Fizz"`  
4. Teste para `n = 5` → espera `"Buzz"`  
5. Teste para `n = 15` → espera `"FizzBuzz"`  

Siga o ciclo **Red → Green → Refactor** a cada nova funcionalidade.

---

## 🧪 Atividades Sugeridas

- Discussão guiada: **por que testar? quando testar?**
- Implementar o Kata FizzBuzz em dupla ou trio, usando TDD
- Apresentar o fluxo básico do `dotnet test`

---

> Próxima sessão: Configuração do ambiente com .NET 8, xUnit e FluentAssertions


### Código fonte de exemplo
