using ProvaDaAcademia.ClassesBase;
using ProvaDaAcademia.ModuloMesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ModuloProduto
{
    internal class ProdutoRepository : RepositoryBase
    {
        public ProdutoRepository(List<EntidadeBase> listaDeEntidades)
        {
            this.listaEntidades = listaDeEntidades;
        }
        public override Produto Busca(int id)
        {
            return (Produto)base.Busca(id);
        }

        public override bool VerificaObjetosComErro(EntidadeBase entidade)
        {
            return false;
        }
    }
}
