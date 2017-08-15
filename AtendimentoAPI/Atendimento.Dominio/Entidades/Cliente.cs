using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atendimento.Dominio.Entidades
{
    public class Cliente
    {
        public string RazaoSocial { get; private set; }
        public int CNPJ { get; private set; }
        public bool Contrato { get; private set; }

        public Cliente()
        {
        }

        public Cliente(string razaoSocial, int cnpj, bool contrato)
        {
            RazaoSocial = razaoSocial;
            CNPJ = cnpj;
            Contrato = contrato;
        }
    }
}
