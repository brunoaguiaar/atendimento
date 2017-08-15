using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atendimento.Dominio.Repositorios
{
    public interface IRepositorioGenerico<T>
    {
        void Criar(T entity);
        T ObterPorId(int id);
        void Alterar(T entity);
        void Deletar(T entity);
        List<T> Listar();
    }
}
