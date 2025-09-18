using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ludoteca.src.models
{
    public class Membro
    {
        public Guid Id { get; private set; } //[AV1-2] encapsulamento
        public string Nome { get; private set; } //[AV1-2] encapsulamento
        public string Matricula { get; private set; } //[AV1-2] encapsulamento

        // Construtor utilizado pelo System.Text.Json durante a desserialização
        [JsonConstructor]
        public Membro(Guid id, string nome, string matricula)
        {
            Id = id;
            Nome = nome;
            Matricula = matricula;
        }
        public Membro(string nome, string matricula) //[AV1-2] Construtor com validações
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do membro não pode ser vazio ou nulo.", nameof(nome));

            if (string.IsNullOrWhiteSpace(matricula))
                throw new ArgumentException("A matricula do membro não pode ser vazio ou nulo.", nameof(matricula));

            Id = Guid.NewGuid();
            Nome = nome;
            Matricula = matricula;
        }
    }
}
