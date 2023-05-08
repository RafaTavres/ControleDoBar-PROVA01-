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
            MesaRepository mesaRepository = new MesaRepository(new List<Mesa>());
            TelaMesa telaMesa = new TelaMesa(mesaRepository);

            GarcomRepository garcomRepository = new GarcomRepository(new List<Garcom>());
            TelaGarcom telaGarcom = new TelaGarcom(garcomRepository);

            ProdutoRepository produtoRepository = new ProdutoRepository(new List<Produto>());
            TelaProduto telaProduto = new TelaProduto(produtoRepository);


            ComandaRepository comandaRepository = new ComandaRepository(new List<Comanda>());
            TelaComanda telaComanda = new TelaComanda(comandaRepository, mesaRepository, telaMesa, produtoRepository,
                telaProduto, garcomRepository, telaGarcom);

            telaProduto.AdicionaAlgunsRegistros();
            telaGarcom.AdicionaAlgunsRegistros();
            telaMesa.AdicionaAlgunsRegistros();
            telaComanda.AdicionaAlgunsRegistros();


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
                    while(opcao.ToUpper() != "S")
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
                    opcao = "";

                }



            }
        }
    }
}