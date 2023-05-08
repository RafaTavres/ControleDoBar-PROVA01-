using ProvaDaAcademia.ClassesBase;

namespace ProvaDaAcademia.ModuloMesa
{
    internal class Mesa : EntidadeBase<Mesa>
    {
        public int numero;
        public string localDaMesa;
        public bool Ocupada;
        public override void Atualizar(Mesa mesa)
        {
            numero = mesa.numero;
            localDaMesa = mesa.localDaMesa;
            Ocupada = mesa.Ocupada;
        }
    }
}
