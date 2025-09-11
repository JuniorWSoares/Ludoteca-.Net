# Ludoteca .NET (AV1)

Sistema em console para cadastro de jogos e membros, empréstimos e devoluções, com persistência em JSON.

## Funcionalidades
- Cadastro de jogos e membros.
- Listagem de jogos. // [AV1-4-Listar]
- Empréstimos e devoluções.
- Persistência em `data/biblioteca.json`. // [AV1-3]
- Tratamento de exceções. // [AV1-5]

## Como rodar
1. `dotnet build`
2. `dotnet run --project src/`

## Estrutura
- `src/` — código fonte.
- `data/biblioteca.json` — armazenamento em JSON.
- `diagramas/` — `Diagrama-Ludoteca.png`
- `evidencias/av1/` — As 4 screenshots.

## Entrega
- Branch `av1`, tag `v1.0`.
- Evidências no diretório indicado.