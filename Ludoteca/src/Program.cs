using Ludoteca.src.models;
using Ludoteca.src.services;
using System;

BibliotecaJogos biblioteca = new BibliotecaJogos();
biblioteca.Carregar(); // [AV1-3] --- carregar dados ao iniciar

bool executando = true;

// [AV1-4-Menu]
while (executando)
{
    Console.Clear();
    Console.WriteLine("\n======== LUDOTECA .NET ========\n");
    Console.WriteLine("1 - Cadastrar jogo");
    Console.WriteLine("2 - Cadastrar membro");
    Console.WriteLine("3 - Listar jogos disponíveis");
    Console.WriteLine("4 - Listar membros");
    Console.WriteLine("5 - Listar empréstimos ativos");
    Console.WriteLine("6 - Emprestar jogo");
    Console.WriteLine("7 - Devolver jogo");
    Console.WriteLine("8 - Gerar Relatório");
    Console.WriteLine("0 - Sair");
    Console.Write("Opção: ");

    string opcao = Console.ReadLine() ?? "";

    try // [AV1-5]
    {
        switch (opcao)
        {
            case "1": // [AV1-4-CadastrarJogo]
                BlocoCadastrarJogo();
                break;

            case "2": // [AV1-4-CadastrarMembro]
                BlocoCadastrarMembro();
                break;

            case "3": // [AV1-4-ListarJogos]
                BlocoListarJogos();
                break;

            case "4": // [AV1-4-ListarMembros]
                BlocoListarMembros();
                break;

            case "5": // [AV1-4-ListarEmprestimos]
                BlocoListarEmprestimos();
                break;

            case "6": // [AV1-4-EmprestarJogo]
                BlocoEmprestarJogo();
                break;

            case "7": // [AV1-4-DevolverJogo]
                BlocoDevolverJogo();
                break;

            case "8": // [AV1-4-Relatorio]
                BlocoGerarRelatorio();
                break;

            case "0": // [AV1-4-Sair]
                biblioteca.Salvar(); // [AV1-3] --- salvar antes de sair
                Console.WriteLine("\nDados salvos. Encerrando...");
                executando = false;
                break;

            default: // [AV1-4-OpçãoInválida]
                Console.Clear();
                Console.WriteLine("Opção inválida.");
                Console.WriteLine("\nPressione 'Enter' para continuar...");
                Console.ReadLine();
                break;
        }
    }
    catch (Exception exception) // [AV1-5]
    {
        Console.WriteLine($"\nErro: {exception.Message}");
        Console.WriteLine("\nPressione 'Enter' para continuar...");
        Console.ReadLine();

        // Registrar log de erros em debug.log
        Directory.CreateDirectory("data");
        File.AppendAllText("data/debug.log", $"[{DateTime.Now}] {exception}\n\n------------------------------------\n\n");
    }
}

void BlocoCadastrarJogo() // [AV1-4-CadastrarJogo]
{
    Console.Clear();
    Console.WriteLine("\n======= CADASTRAR JOGO =======");
    Console.Write("\nNome do jogo: ");
    string nomeJogo = Console.ReadLine()!;
    Console.Write("Categoria: ");
    string categoria = Console.ReadLine()!;
    biblioteca.CadastrarJogo(new Jogo(nomeJogo, categoria));
    biblioteca.Salvar(); // [AV1-3] --- salvar após cada alteração
    Console.WriteLine("\nJogo cadastrado com sucesso!");
    Console.WriteLine("\nPressione 'Enter' para continuar...");
    Console.ReadLine();
}

void BlocoCadastrarMembro() // [AV1-4-CadastrarMembro]
{
    Console.Clear();
    Console.WriteLine("\n====== CADASTRAR MEMBRO ======");
    Console.Write("\nNome do membro: ");
    string nomeMembro = Console.ReadLine()!;
    Console.Write("Matrícula: ");
    string matricula = Console.ReadLine()!;
    biblioteca.CadastrarMembro(new Membro(nomeMembro, matricula));
    biblioteca.Salvar(); // [AV1-3] --- salvar após cada alteração
    Console.WriteLine("\nMembro cadastrado com sucesso!");
    Console.WriteLine("\nPressione 'Enter' para continuar...");
    Console.ReadLine();
}

void BlocoListarJogos() // [AV1-4-ListarJogos]
{
    Console.Clear();
    IEnumerable<Jogo> jogos = biblioteca.ListarJogosDisponiveis();
    Console.WriteLine("\n================ LISTA DE JOGOS ================\n");

    foreach (Jogo jogo in jogos)
    {
        Console.WriteLine($"id do jogo: {jogo.Id}");
        Console.WriteLine($"Nome: {jogo.Nome}");
        Console.WriteLine($"Categoria: {jogo.Categoria}\n");
    }

    Console.WriteLine("================================================");
    Console.WriteLine("\nPressione 'Enter' para continuar...");
    Console.ReadLine();
}

void BlocoListarMembros() // [AV1-4-ListarMembros]
{
    Console.Clear();
    IEnumerable<Membro> membros = biblioteca.ListarMembros();
    Console.WriteLine("\n=============== LISTA DE MEMBROS ===============\n");
    foreach (Membro membro in membros)
    {
        Console.WriteLine($"id do membro: {membro.Id}");
        Console.WriteLine($"Nome: {membro.Nome}");
        Console.WriteLine($"Matrícula: {membro.Matricula}\n");
    }
    Console.WriteLine("================================================");
    Console.WriteLine("\nPressione 'Enter' para continuar...");
    Console.ReadLine();
}
void BlocoListarEmprestimos() // [AV1-4-ListarEmprestimos]
{
    Console.Clear();
    IEnumerable<Emprestimo> emprestimos = biblioteca.ListarEmprestimosAtivos();
    Console.WriteLine("\n============= LISTA DE EMPRÉSTIMOS =============\n");
    foreach (Emprestimo emprestimo in emprestimos)
    {
        Console.WriteLine($"id do emprestimo: {emprestimo.Id}");
        Console.WriteLine($"Jogo: {emprestimo.Jogo.Nome}");
        Console.WriteLine($"Membro: {emprestimo.Membro.Nome}");
        Console.WriteLine($"Data Empréstimo: {emprestimo.DataEmprestimo}\n");
    }
    Console.WriteLine("================================================");
    Console.WriteLine("\nPressione 'Enter' para continuar...");
    Console.ReadLine();
}

void BlocoEmprestarJogo() // [AV1-4-EmprestarJogo]
{
    Console.Clear();
    Console.WriteLine("\n================== EMPRÉSTIMO ==================");
    Console.Write("\nID do jogo: ");
    Guid jogoId = Guid.Parse(Console.ReadLine()!);
    Console.Write("ID do membro: ");
    Guid membroId = Guid.Parse(Console.ReadLine()!);
    biblioteca.EmprestarJogo(jogoId, membroId);
    biblioteca.Salvar(); // [AV1-3] --- salvar após cada alteração
    Console.WriteLine("\nEmpréstimo registrado!");
    Console.WriteLine("\nPressione 'Enter' para continuar...");
    Console.ReadLine();
}

void BlocoDevolverJogo() // [AV1-4-DevolverJogo]
{
    Console.Clear();
    Console.WriteLine("\n================== DEVOLUÇÃO ===================\n");
    Console.Write("ID do empréstimo: ");
    Guid emprestimoId = Guid.Parse(Console.ReadLine()!);
    Emprestimo emprestimo = biblioteca.DevolverJogo(emprestimoId);
    biblioteca.Salvar(); // [AV1-3] --- salvar após cada alteração
    Console.WriteLine("\nJogo devolvido!");
    if (emprestimo.Multa > 0m)
    {
        Console.WriteLine($"\nMulta por atraso: R$ {emprestimo.Multa:F2}");
        Console.WriteLine("Poderá ser pago por pix ou dinheiro.");
    }
    else
    {
        Console.WriteLine("\nNenhuma multa por atraso.");
    }
    Console.WriteLine("\nPressione 'Enter' para continuar...");
    Console.ReadLine();
}

void BlocoGerarRelatorio() // [AV1-4-Relatorio]
{
    Console.Clear();
    Console.WriteLine("\n================== RELATÓRIO ===================\n");
    biblioteca.GerarRelatorio();
    biblioteca.Salvar(); // [AV1-3] --- salvar após cada alteração
    Console.WriteLine("Relatório gerado em data/relatorio.txt");
    Console.WriteLine("\nPressione 'Enter' para continuar...");
    Console.ReadLine();
}