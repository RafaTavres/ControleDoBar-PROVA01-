using ProvaDaAcademia.ClassesBase;
using ProvaDaAcademia.ModuloMesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ModuloProduto
{
    internal class TelaProduto : TelaBase<Produto,ProdutoRepository>
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
            Produto produto = PegaDadosEntidade();
            Adiciona("produto", produto, produtoRepository);

        }
        public override void EscreveTodasAsEntidades(Produto f)
        {
            Console.WriteLine($"id: {f.id} | Nome: {f.nome} | Tipo : {f.tipo} | Preço: {f.preco}");
            Console.WriteLine("____________________________________________________________________________");

        }
        public void MostraTodasOsProdutos()
        {
            MostraTodasEntidade("Produto", produtoRepository);
        }

        public override Produto PegaDadosEntidade()
        {
            Produto produto = new Produto();
            try
            {
                Console.WriteLine("Preço do Produto:");
                produto.preco = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                MensagemDeAviso("Digite um numero válido...");
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
