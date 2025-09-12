using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoteca.src.models
{
    public class Emprestimo
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Jogo Jogo { get; private set; }
        public Membro Membro { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime? DataDevolucao { get; private set; }
        public decimal Multa { get; private set; } = 0m;
        public Emprestimo( Jogo jogo, Membro membro)
        {
            Membro = membro ?? throw new ArgumentNullException(nameof(membro), "O membro não pode ser nulo.");
            Jogo = jogo ?? throw new ArgumentNullException(nameof(jogo), "O jogo não pode ser nulo.");
            if (jogo.EstaEmprestado)
                throw new InvalidOperationException("O jogo já está emprestado.");

            DataEmprestimo = DateTime.Now;
            DataDevolucao = null;
            jogo.Emprestar();
        }
        public void CalcularMulta()
        {
            if (DataDevolucao == null )
            {
              throw new InvalidOperationException("O jogo ainda não foi devolvido.");
            }

            decimal valorPorDia = 2.0m;
            int diasComJogo = (DataDevolucao.Value - DataEmprestimo).Days;
            int diasAtraso = diasComJogo - 7; // Considerando 7 dias como período padrão de empréstimo

            if (diasAtraso > 0)
            {
                Multa = diasAtraso * valorPorDia;
            }
            else
            {
                Multa = 0m;
            }
        }
        public void Devolver()
        {
            if (DataDevolucao != null)
                throw new InvalidOperationException("O jogo já foi devolvido.");
            DataDevolucao = DateTime.Now;
            Jogo.Devolver();
        }
    }
}
