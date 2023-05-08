using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ClassesBase
{
    internal abstract class RepositoryBase<Te> where Te : EntidadeBase<Te>
    {
        protected int id = 1;
        protected List<Te> listaEntidades = new List<Te>();
        public abstract bool VerificaObjetosComErro(Te entidade);

        private int IncrementaId()
        {
            return id++;
        }
        public void Inserir(Te entidade)
        {
            entidade.id = id;
            listaEntidades.Add(entidade);
            IncrementaId();
        }
        public void Atualizar(int id, Te entidade)
        {
            Te entidade2 = Busca(id);
            entidade2.Atualizar(entidade);
        }
        public virtual Te Busca(int id)
        {
            Te entidade = null;
            return entidade = listaEntidades.Find(e => e.id == id);
        }
        public void Deletar(int id)
        {
            foreach (Te a in listaEntidades)
            {

                if (Busca(id).Equals(a))
                {
                    listaEntidades.Remove(a);
                    return;
                }
            }
        }
        public List<Te> RetornarTodos()
        {
            return listaEntidades;
        }

    }
}
