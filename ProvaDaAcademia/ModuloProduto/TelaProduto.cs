using ProvaDaAcademia.ClassesBase;
using ProvaDaAcademia.ModuloMesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ModuloProduto
{
    internal class TelaProduto : TelaBase
    {
        public ProdutoRepository produtoRepository;

        public TelaProduto(ProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public void MenuProduto(string opcao)
        {
            MenuInicial("Produto", opcao);
        }
        public void AdicionaProduto()
        {
            Produto produto = (Produto)PegaDadosEntidade();
            Adiciona("produto", produto, produtoRepository);

        }
        public override void EscreveTodasAsEntidades(EntidadeBase a)
        {
            Produto f = (Produto)a;
            Console.WriteLine($"id: {f.id} | Nome: {f.nome} | Tipo : {f.tipo} | Preço: {f.preco}");

        }
        public void MostraTodasOsProdutos()
        {
            MostraTodasEntidade("Produto", produtoRepository);
        }

        public override EntidadeBase PegaDadosEntidade()
        {
            Produto produto = new Produto();
            try
            {
                Console.WriteLine("Preço do Produto:");
                produto.preco = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                ApresentaMensagem("Digite um numero válido...", ConsoleColor.DarkYellow);
                PegaDadosEntidade();
            }

            Console.WriteLine("Nome do Produto:");
            produto.nome = Console.ReadLine();

            Console.WriteLine("Tipo do Produto:");
            produto.tipo = Console.ReadLine();

            return produto;

        }
        public void AdicionaAlgunsRegistros()
        {
            Produto produto = new Produto();         
            produto.preco = 32.2;    
            produto.nome = "Cerveja";
            produto.tipo = "bebida";
            Adiciona("produto", produto, produtoRepository);
        }
        public void AtualizarProduto()
        {
            AtualizarEntidade(produtoRepository);
        }
        public void DeletaProduto()
        {
            DeletaEntidade(produtoRepository);
        }
        public override void MenuEntidade(string opcao)
        {
            if (opcao == "1")
            {
                Console.Clear();
                AdicionaProduto();
            }
            if (opcao == "2")
            {
                Console.Clear();
                MostraTodasOsProdutos();
                Console.ReadKey();
            }
            if (opcao == "3")
            {
                Console.Clear();
                MostraTodasOsProdutos();
                AtualizarProduto();
            }
            if (opcao == "4")
            {
                Console.Clear();
                MostraTodasOsProdutos();
                DeletaProduto();
            }
        }
    }
}
