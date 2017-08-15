using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atendimento.Dominio.Models
{
    public class UsuarioBaseModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UserName { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Senha { get; set; }
        public virtual List<AtendimentoModel> Atendimentos { get; set; }

        public UsuarioBaseModel(int id, string nome, string userName, DateTime dataCadastro)
        {
            this.Id = id;
            this.Nome = nome;
            this.UserName = userName;
            this.DataCadastro = dataCadastro;
            this.Atendimentos = new List<AtendimentoModel>();
        }

        public UsuarioBaseModel(int id, string nome, string userName)
        {
            this.Id = id;
            this.Nome = nome;
            this.UserName = userName;
        }
    }
}
