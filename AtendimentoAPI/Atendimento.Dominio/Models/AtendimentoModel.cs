using Atendimento.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atendimento.Dominio.Models
{
    public class AtendimentoModel
    {
        public int Id { get; set; }
        public UsuarioBaseModel Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public Status Status { get; set; }
    }
}
