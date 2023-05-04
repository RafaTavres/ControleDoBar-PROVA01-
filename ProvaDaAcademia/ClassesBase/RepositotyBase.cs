using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ClassesBase
{
    internal abstract class RepositoryBase<T>
    {
        protected int id = 1;
        protected List<EntidadeBase> listaEntidades = new List<EntidadeBase>();
        public abstract bool VerificaObjetosComErro(EntidadeBase entidade);

        private int IncrementaId()
        {
            return id++;
        }
        public void Inserir(EntidadeBase entidade)
        {
            entidade.id = id;
            listaEntidades.Add(entidade);
            IncrementaId();
        }
        public void Atualizar(int id, EntidadeBase entidade)
        {
            EntidadeBase entidade2 = Busca(id);
            entidade2.Atualizar(entidade);
        }
        public virtual EntidadeBase Busca(int id)
        {
            EntidadeBase entidade = null;

            foreach (EntidadeBase a in listaEntidades)
            {
                if (a.id == id)
                {
                    entidade = a;
                    return entidade;
                }
            }
            return entidade;
        }
        public void Deletar(int id)
        {
            foreach (EntidadeBase a in listaEntidades)
            {

                if (Busca(id).Equals(a))
                {
                    listaEntidades.Remove(a);
                    return;
                }
            }
        }
        public List<EntidadeBase> RetornarTodos()
        {
            return listaEntidades;
        }

    }
}
