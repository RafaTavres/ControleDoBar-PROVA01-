using Microsoft.VisualBasic.FileIO;
using ProvaDaAcademia.ClassesBase;
using ProvaDaAcademia.ModuloGarcom;
using ProvaDaAcademia.ModuloMesa;
using ProvaDaAcademia.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ModuloComanda
{
    internal class TelaComanda : TelaBase<Comanda,ComandaRepository>
    {
        public ComandaRepository comandaRepository;
        public MesaRepository mesaRepository;
        public TelaMesa telaMesa;
        public ProdutoRepository produtoRepository;
        public TelaProduto telaProduto;
        public GarcomRepository garcomRepository;
        public TelaGarcom telaGarcom;
        public List<Pedido> listaDePedidos;

        public TelaComanda(ComandaRepository comandaRepository, MesaRepository mesaRepository, TelaMesa telamesa, ProdutoRepository produtoRepository, TelaProduto telaProduto,
            GarcomRepository garcomRepository, TelaGarcom telaGarcom)
        {
            this.comandaRepository = comandaRepository;
            this.mesaRepository = mesaRepository;
            this.telaMesa = telamesa;
            this.produtoRepository = produtoRepository;
            this.telaProduto = telaProduto;
            this.telaGarcom = telaGarcom;
            this.garcomRepository = garcomRepository;
        }

        public void MenuComanda(string opcao)
        {
            MenuInicial("Comanda", opcao);
        }
        public void AbrirComanda()
        {
            Comanda comanda = (Comanda)PegaDadosEntidade();
            Adiciona("Comanda", comanda, comandaRepository);
        }

        public override void MenuEntidade(string opcao)
        {

            if (opcao == "1")
            {
                Console.Clear();
                AbrirComanda();
            }
            if (opcao == "2")
            {
                Console.Clear();
                VizualizarComandasAbertas();
                Console.ReadKey();
            }
            if (opcao == "3")
            {
                Console.Clear();
                VizualizarComandas();
                FecharComanda();
                Console.ReadKey();
            }
            if (opcao == "4")
            {
                Console.Clear();
                VizualizarFaturamentoDeHoje();
                Console.ReadKey();
            }
            if (opcao == "5")
            {
                Console.Clear();
                AdicionarPedidosAComanda();
                Console.ReadKey();
            }
            if (opcao == "6")
            {
                Console.Clear();
                DeletarPedidosDaComanda();
                Console.ReadKey();
            }
        }
        public void VizualizarComandasAbertas()
        {
            MostraTodasEntidadeAbertas("Comandas", comandaRepository);
        }
        public void VizualizarComandas()
        {
            MostraTodasEntidade("Comandas", comandaRepository);
        }
        public void VizualizarFaturamentoDeHoje()
        {
            Console.WriteLine("Faturamento diário:");
            Console.WriteLine(faturamentoDiario);
            
        }
        public void MostraTodasEntidadeAbertas(string tipoDeEntidade, ComandaRepository repositorio)
        {
            Console.WriteLine($"{tipoDeEntidade}: ");
            Console.WriteLine("____________________________________________________________________________");
            if (VerificaListasValidas(tipoDeEntidade, repositorio) == true)
            {
                foreach (var item in repositorio.RetornarTodos())
                {
                    int i = 1;
                    if (comandaRepository.Busca(i).EmAberto == true)
                    {
                        EscreveTodasAsEntidades(item);
                    }
                    i++;
                }
               
            }
        }

        public override Comanda PegaDadosEntidade()
        {
            int idDeBusca = 0;
            Comanda comanda = new Comanda();
            try
            {
                
                telaMesa.MostraTodasAsMesas();
                Console.WriteLine("Id da Mesa");
                idDeBusca = Convert.ToInt32(Console.ReadLine());
                comanda.mesa = mesaRepository.BuscaMesasVazias(idDeBusca);                

                telaGarcom.MostraTodasOsGarcons();
                Console.WriteLine("Id do Garcom");
                idDeBusca = Convert.ToInt32(Console.ReadLine());
                comanda.garcom = garcomRepository.Busca(idDeBusca);
            }
            catch (FormatException)
            {
                MensagemDeAviso("Id inválido... ");
                PegaDadosEntidade();
            }
            comanda.diaDeAbertura = DateTime.Now.Date;

            comanda.EmAberto = true;
            if (comanda.mesa.Ocupada != null)
                comanda.mesa.Ocupada = true;

            comanda.listaDePedidos = new List<Pedido>();
            return comanda;
        }
        public void AdicionaAlgunsRegistros()
        {
            int idDeBusca = 1;

            Comanda comanda = new Comanda();
            comanda.mesa = mesaRepository.Busca(idDeBusca);
            comanda.garcom = garcomRepository.Busca(idDeBusca);
            comanda.diaDeAbertura = DateTime.Now.Date;
            comanda.listaDePedidos= new List<Pedido>();
            comanda.EmAberto = true;
            Adiciona("comanda", comanda,comandaRepository);
        }
        public void AdicionarPedidosAComanda()
        {
            VizualizarComandas();
            Console.WriteLine("ID da Comanda");
            int idDaBusca = 0;
            try 
            { 
                idDaBusca = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                MensagemDeAviso("Formato Inválido");
                Console.Clear();
                return;
            }
            Comanda comanda = comandaRepository.Busca(idDaBusca);
            if(comanda.EmAberto ==  true)
            {
                Console.WriteLine("Pedidos:");
                comanda.pedido = RegistrarPedidos();               
                comanda.listaDePedidos.Add(comanda.pedido);
                comanda.quantidadeParaPagar += Convert.ToInt32(comanda.pedido.produto.preco * comanda.pedido.quantidade);
                MensagemDeSucesso("Pedido Adiciona com sucesso");
            }
            else
            {
                MensagemDeAviso("Comanda Já fechada");
            }

        }
        public void DeletarPedidosDaComanda()
        {
            VizualizarComandas();
            Console.WriteLine("ID da Comanda");
            int idDaBusca = Convert.ToInt32(Console.ReadLine());
            Comanda comanda = comandaRepository.Busca(idDaBusca);
            comanda.listaDePedidos.Remove(comanda.pedido);
            comanda.listaDePedidos = listaDePedidos;
            MensagemDeSucesso("Pedido deletado com sucesso");
            comanda.quantidadeParaPagar -= Convert.ToInt32(comanda.pedido.produto.preco * comanda.pedido.quantidade);
        }
        public void FecharComanda()
        {
            Console.WriteLine("Id da Comanda");
            int idDeBusca = Convert.ToInt32(Console.ReadLine());
            Comanda comanda = comandaRepository.Busca(idDeBusca);
            comanda.EmAberto = false;
            if(comanda.diaDeAbertura == DateTime.UtcNow.Date) 
            {

                faturamentoDiario += comanda.quantidadeParaPagar;
            }
            MensagemDeSucesso("Comanda fechada com sucesso");
        }

        public Pedido RegistrarPedidos()
        {
            Pedido pedido = new Pedido();
            int IdBusca = 0;
            Console.WriteLine("Quantidade do pedido");
            pedido.quantidade = Convert.ToInt32(Console.ReadLine());
            telaProduto.MostraTodasOsProdutos();
            Console.WriteLine("Id do Produto:");
            IdBusca = Convert.ToInt32(Console.ReadLine());
            pedido.produto = produtoRepository.Busca(IdBusca);
            return pedido;
        }

        public override void EscreveTodasAsEntidades(Comanda f)
        {
            Console.WriteLine($"id: {f.id} | Quantidade para Pagar: {f.quantidadeParaPagar} | Em Aberto: {f.EmAberto} | Dia da Abertura { f.diaDeAbertura.Date}");
            Console.WriteLine("Lista de Pedidos");
            foreach (var item in f.listaDePedidos)
            {
                
                Console.WriteLine($"Produto {item.produto.nome} | Quantidade {item.quantidade}");

            }
            Console.WriteLine("____________________________________________________________________________");
        }
        public override void MenuInicial(string nome, string opcao)
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"----Menu {nome}----\n");
                Console.WriteLine($"1- Abrir {nome} | 2- Ver todas {nome} em aberto | 3- fechar {nome} | 4- Vizualizar total faturado do dia| 5- Adicionar Pedidos a Comanda | 6- Deletar Pedidos da Comanda S- Sair");
                opcao = Console.ReadLine();
                MenuEntidade(opcao);

            }
            while (opcao.ToUpper() != "S");
        }
    }
    
}
