using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ludoteca.src.models
{
    public class Jogo
    {
        public Guid Id { get; private set; } //[AV1-2] encapsulamento
        public string Nome { get; private set; } //[AV1-2] encapsulamento
        public string Categoria { get; private set; } //[AV1-2] encapsulamento
        public bool EstaEmprestado { get; private set; } //[AV1-2] encapsulamento

        // Construtor utilizado pelo System.Text.Json durante a desserialização
        [JsonConstructor]
        public Jogo(Guid id, string nome, string categoria, bool estaEmprestado) 
        { 
            Id = id;
            Nome = nome;
            Categoria = categoria;  
            EstaEmprestado = estaEmprestado;
        }
        public Jogo(string nome, string categoria) //[AV1-2] Construtor com validações
        { 
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do jogo não pode ser vazio ou nulo.", nameof(nome));

            if (string.IsNullOrWhiteSpace(categoria))
                throw new ArgumentException("A categoria do jogo não pode ser vazio ou nulo.", nameof(categoria));

            Id = Guid.NewGuid();
            Nome = nome;
            Categoria = categoria;  
            EstaEmprestado = false;
        }

        public void Emprestar()
        {
            EstaEmprestado = true;
        }

        public void Devolver()
        {
            EstaEmprestado = false;
        }
    }
}
