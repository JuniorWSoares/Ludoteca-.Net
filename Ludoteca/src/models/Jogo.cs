using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoteca.src.models
{
    public class Jogo
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; }
        public string Categoria { get; private set; }
        public bool EstaEmprestado { get; private set; }

        public Jogo(string nome, string categoria) 
        { 
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do jogo não pode ser vazio ou nulo.", nameof(nome));

            if (string.IsNullOrWhiteSpace(categoria))
                throw new ArgumentException("A categoria do jogo não pode ser vazio ou nulo.", nameof(categoria));

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
