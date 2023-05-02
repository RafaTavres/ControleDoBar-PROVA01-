using ProvaDaAcademia.ClassesBase;
using ProvaDaAcademia.ModuloComanda;
using ProvaDaAcademia.ModuloGarcom;
using ProvaDaAcademia.ModuloMesa;
using ProvaDaAcademia.ModuloProduto;
using System.Security.Cryptography.X509Certificates;

namespace ProvaDaAcademia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcao = "";
            MesaRepository mesaRepository = new MesaRepository(new List<EntidadeBase>());
            TelaMesa telaMesa = new TelaMesa(mesaRepository);

            GarcomRepository garcomRepository = new GarcomRepository(new List<EntidadeBase>());
            TelaGarcom telaGarcom = new TelaGarcom(garcomRepository);

            ProdutoRepository produtoRepository = new ProdutoRepository(new List<EntidadeBase>());
            TelaProduto telaProduto = new TelaProduto(produtoRepository);


            ComandaRepository comandaRepository = new ComandaRepository(new List<EntidadeBase>());
            TelaComanda telaComanda = new TelaComanda(comandaRepository, mesaRepository, telaMesa, produtoRepository,
                telaProduto, garcomRepository, telaGarcom);

            telaProduto.AdicionaAlgunsRegistros();



            while (opcao.ToUpper() != "S")
            {
                Console.Clear();
                Console.WriteLine("1- Menu Comanda | 2- Menu Funcionario |  S- sair");
                opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    telaComanda.MenuComanda(opcao);
                }
                if (opcao == "2")
                {
                    Console.Clear();
                    Console.WriteLine("1- Menu Garcom | 2- Menu Mesa | 3- Menu Produto  S- sair");
                    opcao = Console.ReadLine();
                    if (opcao == "1")
                    {
                        telaGarcom.MenuGarcom(opcao);
                    }
                    if (opcao == "2")
                    {
                        telaMesa.MenuMesa(opcao);
                    }
                    if (opcao == "3")
                    {
                        telaProduto.MenuProduto(opcao);
                    }
                }



            }
        }
    }
}