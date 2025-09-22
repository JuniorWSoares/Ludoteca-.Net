# Ludoteca .NET (AV1)

Sistema em console para cadastro de jogos e membros, empréstimos e devoluções, com persistência em JSON.

## Diagrama UML
`Ludoteca/diagramas/Diagrama-Ludoteca.png`

## Classes
- Jogo;
- Membro;
- Emprestimo;
- BibliotecaJogos.

## Funcionalidades
- Cadastro de jogo;
- Cadastro de membro;
- Listagem de jogos disponíveis;
- Listagem de membros;
- Listagem de emprestimos ativos;
- Faz empréstimo de um jogo;
- Faz devolução de um jogo;
- Calcula multa por dias de atraso;
- Gera relatório em `data/relatorio.txt`;
- Persistência em `data/biblioteca.json`;
- Log de erros em `data/debug.log`;
- Tratamento de exceções.

## Link do vídeo com a demonstração do sistema
...

## Como rodar
Na raiz do projeto, rodar:
1. `dotnet build`
2. `dotnet run`

## Estrutura
- `src/` — código fonte.
- `data/biblioteca.json` — armazenamento em JSON.
- `diagramas/` — `Diagrama-Ludoteca.png`
- `evidencias/av1/` — As 4 screenshots.

## Entrega
- Branch `av1`, tag `v1.0`.
- Evidências no diretório indicado.
