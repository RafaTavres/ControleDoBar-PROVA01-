using ProvaDaAcademia.ClassesBase;
using ProvaDaAcademia.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ModuloMesa
{
    internal class TelaMesa : TelaBase
    {
        public MesaRepository<Mesa> mesaRepository;

        public TelaMesa(MesaRepository<Mesa> mesaRepository)
        {
            this.mesaRepository = mesaRepository;
        }

        public void MenuMesa(string opcao)
        {
            MenuInicial("Mesa", opcao);
        }
        public void AdicionaMesa()
        {
            Mesa mesa = (Mesa)PegaDadosEntidade();
            Adiciona("Mesa", mesa, mesaRepository);

        }
        public override void EscreveTodasAsEntidades(EntidadeBase a)
        {
            Mesa f = (Mesa)a;
            Console.WriteLine($"id: {f.id} | Numero: {f.numero} | Ocupada?: {f.Ocupada} | Local: {f.localDaMesa}");
            Console.WriteLine("____________________________________________________________________________");

        }
        public void MostraTodasAsMesas()
        {
            MostraTodasEntidade("Mesa", mesaRepository);
        }

        public override EntidadeBase PegaDadosEntidade()
        {
            Mesa mesa = new Mesa();
            try
            {
                Console.WriteLine("Numero da Mesa:");
                mesa.numero = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException )
            {
                ApresentaMensagem("Digite um numero válido...", ConsoleColor.DarkYellow);
                PegaDadosEntidade();
            }

            Console.WriteLine("Local da Mesa:");
            mesa.localDaMesa = Console.ReadLine();

            mesa.Ocupada = false;

            return mesa;

        }
        public void AdicionaAlgunsRegistros()
        {
            Mesa mesa = new Mesa();
            mesa.numero = 1;
            mesa.localDaMesa = "perto dos vasos";
            mesa.Ocupada = false;
            Adiciona("mesa", mesa, mesaRepository);
        }
        public void AtualizarMesa()
        {
            AtualizarEntidade(mesaRepository);
        }
        public void DeletaMesa()
        {
            DeletaEntidade(mesaRepository);
        }
        public override void MenuEntidade(string opcao)
        {
            if (opcao == "1")
            {
                Console.Clear();
                AdicionaMesa();
            }
            if (opcao == "2")
            {
                Console.Clear();
                MostraTodasAsMesas();
                Console.ReadKey();
            }
            if (opcao == "3")
            {
                Console.Clear();
                MostraTodasAsMesas();
                AtualizarMesa();
            }
            if (opcao == "4")
            {
                Console.Clear();
                MostraTodasAsMesas();
                DeletaMesa();
            }
        }

    }
}

