using ProvaDaAcademia.ClassesBase;
using ProvaDaAcademia.ModuloGarcom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ModuloComanda
{
    internal class ComandaRepository : RepositoryBase<Comanda>
    {
        public ComandaRepository(List<Comanda> listaDeEntidades)
        {
            this.listaEntidades = listaDeEntidades;
        }

        public override bool VerificaObjetosComErro(Comanda c)
        {
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
