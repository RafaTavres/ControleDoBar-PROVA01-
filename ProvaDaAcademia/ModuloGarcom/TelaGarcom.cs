using ProvaDaAcademia.ClassesBase;

namespace ProvaDaAcademia.ModuloGarcom
{
    internal class TelaGarcom : TelaBase<Garcom, GarcomRepository>
    {
        public GarcomRepository garcomRepository;

        public TelaGarcom(GarcomRepository garcomRepository)
        {
            this.garcomRepository = garcomRepository;
        }

        public void MenuGarcom(string opcao)
        {
            MenuInicial("Garçom", opcao);
        }
        public void AdicionaGarcom()
        {
            Garcom garcom = (Garcom)PegaDadosEntidade();
            Adiciona("Garçom", garcom, garcomRepository);

        }
        public override void EscreveTodasAsEntidades(Garcom f)
        {
            Console.WriteLine($"id: {f.id} | Nome: {f.nome} | CNPJ : {f.CNPJ}");
            Console.WriteLine("____________________________________________________________________________");

        }
        public void MostraTodasOsGarcons()
        {
            MostraTodasEntidade("Garcom", garcomRepository);
        }

        public override Garcom PegaDadosEntidade()
        {
            Garcom garcom = new Garcom();
            try
            {
                Console.WriteLine("CNPJ do Garçom:");
                garcom.CNPJ = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                MensagemDeAviso("Digite um numero válido...");
                PegaDadosEntidade();
            }

            Console.WriteLine("Nome do Garçom:");
            garcom.nome = Console.ReadLine();

            return garcom;

        }
        public void AdicionaAlgunsRegistros()
        {
            Garcom garcom = new Garcom();
            garcom.CNPJ = 12131;
            garcom.nome = "Marcos";
            Adiciona("garcom", garcom, garcomRepository);
        }
        public void AtualizaGarcom()
        {
            AtualizarEntidade(garcomRepository);
        }
        public void DeletaGarcom()
        {
            DeletaEntidade(garcomRepository);
        }
        public override void MenuEntidade(string opcao)
        {
            if (opcao == "1")
            {
                Console.Clear();
                AdicionaGarcom();
            }
            if (opcao == "2")
            {
                Console.Clear();
                MostraTodasOsGarcons();
                Console.ReadKey();
            }
            if (opcao == "3")
            {
                Console.Clear();
                MostraTodasOsGarcons();
                AtualizaGarcom();
            }
            if (opcao == "4")
            {
                Console.Clear();
                MostraTodasOsGarcons();
                DeletaGarcom();
            }
        }
    }
}
