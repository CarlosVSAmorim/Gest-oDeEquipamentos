using System.Collections.Generic;
using System.Linq;

namespace GestãoDeEquipamentos
{
    public class RepositorioBase<T> where T : EntidadeBase
    {
        protected List<T> lista = new List<T>();
        protected int proximoId = 1;

        public virtual void Adicionar(T entidade)
        {
            entidade.Id = proximoId++;
            lista.Add(entidade);
        }

        public virtual void Editar(int id, T novaEntidade)
        {
            var existente = ObterPorId(id);
            if (existente != null)
            {
                int index = lista.IndexOf(existente);
                novaEntidade.Id = id;
                lista[index] = novaEntidade;
            }
        }

        public virtual void Excluir(int id)
        {
            var entidade = ObterPorId(id);
            if (entidade != null)
                lista.Remove(entidade);
        }

        public virtual T ObterPorId(int id)
        {
            return lista.FirstOrDefault(e => e.Id == id);
        }

        public virtual List<T> ListarTodos()
        {
            return new List<T>(lista);
        }
    }
}