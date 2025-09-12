using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoteca.src.models
{
    public class Membro
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; }
        public string Matricula { get; private set; }
        public Membro(string nome, string matricula)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do membro não pode ser vazio ou nulo.", nameof(nome));

            if (string.IsNullOrWhiteSpace(matricula))
                throw new ArgumentException("A matricula do membro não pode ser vazio ou nulo.", nameof(matricula));

            Nome = nome;
            Matricula = matricula;
        }
    }
}
