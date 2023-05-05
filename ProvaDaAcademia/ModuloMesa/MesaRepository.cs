using ProvaDaAcademia.ClassesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ModuloMesa
{
    internal class MesaRepository : RepositoryBase<Mesa>
    {
        public MesaRepository(List<Mesa> listaDeEntidades)
        {
            this.listaEntidades = listaDeEntidades;
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

        public override bool VerificaObjetosComErro(Mesa     entidade)
        {
            return false;
        }
    }
}
