# Ludoteca .NET

Sistema em console para cadastro de jogos e membros, empréstimos e devoluções, com persistência em JSON.

## Grupo
José Júnior Warol Soares - 06012771
Watilha de Lima Soares - 06012734

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
AV1 - https://drive.google.com/file/d/1Ci1ekdoLgnSFFLBZDEULvL5uwTwY5Rm-/view?usp=sharing

## Como rodar
Na raiz do projeto, rodar:
1. `dotnet build`
2. `dotnet run`

## Estrutura
- `Ludoteca/src/` — código fonte.
- `Ludoteca/data/biblioteca.json` — armazenamento em JSON. *Criada em tempo de execução*
- `Ludoteca/diagramas/` — `Diagrama-Ludoteca.png`
- `Ludoteca/evidencias/av1/` — As 4 screenshots.

## Entrega
- Branch `av1`, tag `v1.0`.
- Branch `av2`, tag `v2.0`.
- Evidências no diretório indicado.
