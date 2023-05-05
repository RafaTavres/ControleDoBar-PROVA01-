using ProvaDaAcademia.ClassesBase;
using ProvaDaAcademia.ModuloMesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ModuloProduto
{
    internal class ProdutoRepository : RepositoryBase<Produto>
    {
        public ProdutoRepository(List<Produto> listaDeEntidades)
        {
            this.listaEntidades = listaDeEntidades;
        }

        public override bool VerificaObjetosComErro(Produto entidade)
        {
            return false;
        }
    }
}
