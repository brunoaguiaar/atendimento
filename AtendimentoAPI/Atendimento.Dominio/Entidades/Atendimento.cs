using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atendimento.Dominio.Entidades
{
    public class Atendimento : EntidadeBase
    {
        public int Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFinal { get; private set; }
        public Status Status { get; private set; }

        protected Atendimento()
        {
        }

        public Atendimento(Usuario usuario, Cliente cliente, String titulo, String descricao)
        {
            Usuario = usuario;
            Cliente = cliente;
            Titulo = titulo;
            Descricao = descricao;
            DataInicio = DateTime.Now;
        }

        public override bool IsValid()
        {
            Mensagens.Clear();

            if (string.IsNullOrWhiteSpace(Titulo))
                Mensagens.Add("Título é invalido");

            if (string.IsNullOrWhiteSpace(Descricao))
                Mensagens.Add("Descrição é inválida");

            if (string.IsNullOrWhiteSpace(Cliente.RazaoSocial))
                Mensagens.Add("Cliente é inválido");

            return Mensagens.Count == 0;
        }

    }
}
