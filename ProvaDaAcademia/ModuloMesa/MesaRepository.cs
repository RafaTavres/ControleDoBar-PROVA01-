using ProvaDaAcademia.ClassesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ModuloMesa
{
    internal class MesaRepository : RepositoryBase
    {
        public MesaRepository(List<EntidadeBase> listaDeEntidades)
        {
            this.listaEntidades = listaDeEntidades;
        }
        public override Mesa Busca(int id)
        {
            return (Mesa)base.Busca(id);
        }

        public override bool VerificaObjetosComErro(EntidadeBase entidade)
        {
            return false;
        }
    }
}
