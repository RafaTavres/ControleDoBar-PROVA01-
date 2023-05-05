using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ClassesBase
{
    public enum TipoMensagem 
    { 
        Sucesso,Erro,Aviso
    }

    internal abstract class TelaBase<Te,Tr> where Te : EntidadeBase<Te> where Tr : RepositoryBase<Te>
    {
        public double faturamentoDiario;


        private void ApresentaMensagem(string mensagem, TipoMensagem tipo)
        {
            ConsoleColor cor = ConsoleColor.White;
            switch (tipo)
            {
                case TipoMensagem.Sucesso: cor = ConsoleColor.Green;
                    break;
                case TipoMensagem.Erro: cor = ConsoleColor.Red;
                    break;
                case TipoMensagem.Aviso: cor = ConsoleColor.DarkYellow;
                    break;

            }
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.WriteLine("Aperte qualquer tecla para continuar...");
            Console.ReadKey();
        }
        protected void MostrarMensagemSucesso()
        {

        }
        public bool VerificaListasValidas(string tipo, Tr repository)
        {
            if (repository.RetornarTodos().Count == 0)
            {
                MensagemDeAviso($"Nenhum {tipo} Registradado");
               
                return false;
            }
            else
            {
                return true;
            }
        }
        public virtual void MenuInicial(string nome, string opcao)
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"----Menu {nome}----\n");
                Console.WriteLine($"1- Adicionar {nome} | 2- Ver {nome} | 3- Atualizar {nome} | 4- Deletar {nome} | S- Sair");
                opcao = Console.ReadLine();
                MenuEntidade(opcao);

            }
            while (opcao.ToUpper() != "S");
        }

        public abstract void MenuEntidade(string opcao);

        protected void Adiciona(string nomeDaEntidade, Te novaEntidade, Tr repositorio)
        {
            if (repositorio.VerificaObjetosComErro(novaEntidade) == true)
            {
                MensagemDeErro($"{nomeDaEntidade} Invalido(a)");
                return;
            }
            else
            {
                repositorio.Inserir(novaEntidade);
                MensagemDeSucesso($"{nomeDaEntidade} Adicionado(a)");
               
            }
        }
        public abstract Te PegaDadosEntidade();

        public virtual void MostraTodasEntidade(string tipoDeEntidade, Tr repositorio)
        {
            Console.WriteLine($"{tipoDeEntidade}: ");
            Console.WriteLine("____________________________________________________________________________");
            if (VerificaListasValidas(tipoDeEntidade, repositorio) == true)
            {
                foreach (Te a in repositorio.RetornarTodos())
                {
                    EscreveTodasAsEntidades(a);
                }

            }
        }
        public abstract void EscreveTodasAsEntidades(Te a);

        public virtual void AtualizarEntidade(Tr repositorio)
        {

            int idParaEditar = BuscaiD(repositorio);
            if (0 == idParaEditar)
                return;
            Te entidade = PegaDadosEntidade();
            repositorio.Atualizar(idParaEditar, entidade);
        }

        public virtual void DeletaEntidade(Tr    repositorio)
        {

            int idParaEditar = BuscaiD(repositorio);
            if (0 == idParaEditar)
                return;

            int idParaDeletar = Convert.ToInt32(Console.ReadLine());
            repositorio.Deletar(idParaDeletar);
        }
        public int BuscaiD(Tr repositorio)
        {
            int idParaDeletar = 0;
            try
            {
                Console.WriteLine();
                Console.WriteLine("Id: ");
                idParaDeletar = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException )
            {
                MensagemDeAviso("Informe um ID válido...");
                BuscaiD(repositorio);
            }

            repositorio.Busca(idParaDeletar);
            if (repositorio.Busca(idParaDeletar) == null)
                return 0;
            else
                return idParaDeletar;
        }

        public void MensagemDeSucesso(string mensagem)
        {
            ApresentaMensagem(mensagem,TipoMensagem.Sucesso);
        }
        public void MensagemDeErro(string mensagem)
        {
            ApresentaMensagem(mensagem, TipoMensagem.Erro);
        }
        public void MensagemDeAviso(string mensagem)
        {
            ApresentaMensagem(mensagem, TipoMensagem.Aviso);
        }
    }
}

