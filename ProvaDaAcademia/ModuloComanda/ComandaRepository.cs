using ProvaDaAcademia.ClassesBase;
using ProvaDaAcademia.ModuloGarcom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ModuloComanda
{
    internal class ComandaRepository<T> : RepositoryBase<EntidadeBase>
    {
        public ComandaRepository(List<EntidadeBase> listaDeEntidades)
        {
            this.listaEntidades = listaDeEntidades;
        }
        public override Comanda Busca(int id)
        {
            return (Comanda)base.Busca(id);
        }

        public override bool VerificaObjetosComErro(EntidadeBase entidade)
        {
            Comanda c = (Comanda)entidade;
            if(c.mesa == null)
            {
                return true;
            }
            if (c.garcom == null)
            {
                return true;
            }
            return false;
        }
    }
}
