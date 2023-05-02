using ProvaDaAcademia.ClassesBase;
using ProvaDaAcademia.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ModuloGarcom
{
    internal class GarcomRepository : RepositoryBase
    {
        public GarcomRepository(List<EntidadeBase> listaDeEntidades)
        {
            this.listaEntidades = listaDeEntidades;
        }
        public override Garcom Busca(int id)
        {
            return (Garcom)base.Busca(id);
        }

        public override bool VerificaObjetosComErro(EntidadeBase entidade)
        {
            return false;
        }
    }
}
