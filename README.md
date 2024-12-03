# **GraphInCSharp**

Este é um projeto em C# para manipulação e análise de grafos utilizando diferentes representações: matriz de adjacência e lista de adjacência.

## 1. Requisitos
Este projeto é baseado no **.NET Framework** e utiliza o compilador `csc` (Visual C# Compiler). Certifique-se de atender aos seguintes requisitos antes de executar:

- **Sistema Operacional**: Windows
- **.NET Framework**: Versão 4.8 ou superior
- **C# Compiler (`csc`)**: Incluído no .NET Framework
- **Editor de Texto**: Qualquer editor que suporte C# (Visual Studio, Notepad++, VS Code, etc.)

## **2. Como executar o projeto**

O projeto já está configurado para ser compilado e executado através de um script `.bat`. Siga os passos abaixo:

1. **Compile e execute o projeto**:
    Antes de executar, certifique-se de que o compilador `csc` está configurado no PATH do sistema.

   Execute o arquivo `compila_and_run.bat` na raiz do projeto:
   - Windows:
     - Basta dar um duplo clique no arquivo `compila_and_run.bat`.
   - Via terminal:
     ```bash
     compila_and_run.bat
     ```

3. O programa será compilado e executado automaticamente. O console exibirá os resultados e interações com os algoritmos de grafos.

---

## 3. Criando um Grafo

### Número de Vértices
- O programa solicitará o número de vértices do grafo.
- Digite um número inteiro positivo.

### Vértices Padrão
- Os vértices são criados automaticamente com IDs sequenciais começando de 1, rotulados como "A", "B", "C", ..., com peso padrão igual a 1.

---

## 4. Menu de Ações
O programa apresenta o menu abaixo. Escolha uma opção digitando o número correspondente.

| Opção | Descrição                                                         |  
|-------|-------------------------------------------------------------------|
| 1     | Adicionar uma aresta                                              |
| 2     | Remover uma aresta                                                |
| 3     | Adicionar rótulo a um vértice                                     |
| 4     | Adicionar peso a um vértice                                       |
| 5     | Adicionar rótulo a uma aresta                                     |
| 6     | Adicionar peso a uma aresta                                       |
| 7     | Verificar adjacência entre dois vértices                          |
| 8     | Verificar vizinhança de um vértice                                |
| 9     | Verificar grau de um vértice                                      |
| 10    | Verificar se o grafo é completo                                   |
| 11    | Verificar se o grafo é regular                                    |
| 12    | Verificar se o grafo é conexo                                     |
| 13    | Verificar se o grafo é acíclico                                   |
| 14    | Verificar se o grafo é Euleriano                                  |
| 15    | Realizar busca em profundidade                                    |
| 16    | Realizar busca em largura                                         |
| 17    | Calcular menor distância de um vértice de origem (Dijkstra)       |
| 18    | Calcular menor distância entre todos os vértices (Floyd-Warshall) |
| 19    | Criar um grafo padrão com vértices e arestas predefinidos         |

---

## 5. Exemplos de Entrada e Saída

### Exemplo 1: Criar Grafo

#### Entrada:
```
Insira o número de vértices: 3
```

#### Saída:
```
Grafo criado com 3 vértices: [A, B, C]
```

---

### Exemplo 2: Adicionar Aresta

#### Entrada:
```
Insira o ID do vértice de origem: 1
Insira o ID do vértice de destino: 2
Insira o peso: 5
```

#### Saída:
```
Aresta adicionada de 1 para 2 com peso 5.
```

---

### Exemplo 3: Verificar Adjacência

#### Entrada:
```
Insira o ID do vértice de origem: 1
Insira o ID do vértice de destino: 2
```

#### Saída:
```
Conectados
```

---

## 6. Finalizando
- Para encerrar o programa, basta fechar o terminal ou pressionar Ctrl + C.