using ProvaDaAcademia.ClassesBase;
namespace ProvaDaAcademia.ModuloGarcom
{
    internal class Garcom : EntidadeBase<Garcom>
    {
        public string nome;
        public int CNPJ;

        public override void Atualizar(Garcom garcom)
        {
            nome = garcom.nome;
            CNPJ = garcom.CNPJ;
        }
    }
}
