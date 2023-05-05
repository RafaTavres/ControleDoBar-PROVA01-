using ProvaDaAcademia.ClassesBase;
using ProvaDaAcademia.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ModuloGarcom
{
    internal class GarcomRepository : RepositoryBase<Garcom>
    {
        public GarcomRepository(List<Garcom> listaDeEntidades) 
        {
            this.listaEntidades = listaDeEntidades;
        }

        public override bool VerificaObjetosComErro(Garcom entidade)
        {
            return false;
        }
    }
}
