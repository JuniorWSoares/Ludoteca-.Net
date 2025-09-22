using Ludoteca.src.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Ludoteca.src.services
{
    public class BibliotecaJogos
    {
        private List<Jogo> jogos = new List<Jogo>(); //[AV1-2]
        private List<Membro> membros = new List<Membro>(); //[AV1-2] 
        private List<Emprestimo> emprestimos = new List<Emprestimo>(); //[AV1-2] 
        public void CadastrarJogo(Jogo jogo)
        {
            if (jogo == null)
                throw new ArgumentNullException(nameof(jogo), "O jogo não pode ser nulo."); //[AV1-2]
            jogos.Add(jogo);
        }
        public void CadastrarMembro(Membro membro)
        {
            if (membro == null)
                throw new ArgumentNullException(nameof(membro), "O membro não pode ser nulo."); //[AV1-2]
            membros.Add(membro);
        }
        public void EmprestarJogo(Guid jogoId, Guid membroId)
        {
            Jogo? jogo = jogos.FirstOrDefault(j => j.Id == jogoId);
            if (jogo == null)
                throw new InvalidOperationException("Jogo não encontrado."); //[AV1-2] 

            if (jogo.EstaEmprestado)
                throw new InvalidOperationException("O jogo já está emprestado."); //[AV1-2]

            Membro? membro = membros.FirstOrDefault(m => m.Id == membroId);
            if (membro == null)
                throw new InvalidOperationException("Membro não encontrado."); //[AV1-2]

            Emprestimo emprestimo = new Emprestimo(jogo, membro);
            emprestimos.Add(emprestimo);
        }
        public Emprestimo DevolverJogo(Guid emprestimoId)
        {
            Emprestimo? emprestimo = emprestimos.FirstOrDefault(e => e.Id == emprestimoId);
            if (emprestimo == null)
                throw new InvalidOperationException("Empréstimo não encontrado."); //[AV1-2]
            Jogo? jogo = jogos.FirstOrDefault(j => j.Id == emprestimo.Jogo.Id);
            if (jogo == null)
                throw new InvalidOperationException("Jogo não encontrado."); //[AV1-2]
            emprestimo.Devolver(jogo);
            emprestimo.CalcularMulta();
            return emprestimo;
        }
        public IEnumerable<Jogo> ListarJogosDisponiveis()
        {
            return jogos.Where(j => !j.EstaEmprestado).ToList();
        }

        public IEnumerable<Membro> ListarMembros()
        {
            return membros;
        }

        public IEnumerable<Emprestimo> ListarEmprestimosAtivos()
        {
            return emprestimos.Where(e => e.DataDevolucao == null).ToList();
        }

        // [AV1-3] --- início da serialização
        public void Salvar()
        {
            BibliotecaDados dados = new BibliotecaDados{
                Jogos = jogos,
                Membros = membros,
                Emprestimos = emprestimos
            };

            string jsonString = JsonSerializer.Serialize(dados, new JsonSerializerOptions { WriteIndented = true });
            Directory.CreateDirectory("data");
            File.WriteAllText("data/biblioteca.json", jsonString);
        }
        // [AV1-3] --- fim

        // [AV1-3] --- início da desserialização
        public void Carregar()
        {
            if (!File.Exists("data/biblioteca.json"))
                return;

            string jsonString = File.ReadAllText("data/biblioteca.json");
            BibliotecaDados? dados = JsonSerializer.Deserialize<BibliotecaDados>(jsonString);

            if (dados != null)
            {
                jogos = dados.Jogos ?? new List<Jogo>();
                membros = dados.Membros ?? new List<Membro>();
                emprestimos = dados.Emprestimos ?? new List<Emprestimo>();
            }
        }
        // [AV1-3] --- fim
        public void GerarRelatorio()
        {
            int totalJogos = jogos.Count;
            int totalMembros = membros.Count;
            int emprestimosAtivos = emprestimos.Count(e => e.DataDevolucao == null);
            int devolvidos = emprestimos.Count(e => e.DataDevolucao != null);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== RELATÓRIO DA LUDOTECA ===");
            sb.AppendLine($"Total de jogos cadastrados: {totalJogos}");
            sb.AppendLine($"Total de membros cadastrados: {totalMembros}");
            sb.AppendLine($"Empréstimos ativos: {emprestimosAtivos}");
            sb.AppendLine($"Empréstimos devolvidos: {devolvidos}");

            Directory.CreateDirectory("data");
            File.WriteAllText("data/relatorio.txt", sb.ToString());
        }

        private class BibliotecaDados
        {
            public List<Jogo> Jogos { get; set; } = new List<Jogo>();
            public List<Membro> Membros { get; set; } = new List<Membro>();
            public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
        }
    }
}
