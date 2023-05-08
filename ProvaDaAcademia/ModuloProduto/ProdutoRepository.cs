using ProvaDaAcademia.ClassesBase;

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
