using ProvaDaAcademia.ClassesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ModuloMesa
{
    internal class MesaRepository<T> : RepositoryBase<EntidadeBase>
    {
        public MesaRepository(List<EntidadeBase> listaDeEntidades)
        {
            this.listaEntidades = listaDeEntidades;
        }
        public override Mesa Busca(int id)
        {
            return (Mesa)base.Busca(id);
        }
        public Mesa BuscaMesasVazias(int id)
        {

            Mesa mesa = (Mesa)base.Busca(id);
            if (mesa != null && mesa.Ocupada == true)
            {
                return null;
            }
            else
                return mesa;
                
        }

        public override bool VerificaObjetosComErro(EntidadeBase entidade)
        {
            return false;
        }
    }
}
