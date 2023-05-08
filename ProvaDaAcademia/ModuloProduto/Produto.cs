using ProvaDaAcademia.ClassesBase;

namespace ProvaDaAcademia.ModuloProduto
{
    internal class Produto : EntidadeBase<Produto>
    {
        public string nome;
        public double preco;
        public string tipo;

        public override void Atualizar(Produto produto)
        {
            nome = produto.nome;
            preco = produto.preco;
            tipo = produto.tipo;
        }

         
    }
}
