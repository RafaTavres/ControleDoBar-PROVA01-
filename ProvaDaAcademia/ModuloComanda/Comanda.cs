using ProvaDaAcademia.ClassesBase;
using ProvaDaAcademia.ModuloGarcom;
using ProvaDaAcademia.ModuloMesa;


namespace ProvaDaAcademia.ModuloComanda
{
    internal class Comanda : EntidadeBase<Comanda>
    {
         
        public int quantidadeParaPagar;
        public Pedido pedido;
        public List<Pedido> listaDePedidos;
        public Garcom garcom;
        public Mesa mesa;
        public bool EmAberto;
        public DateTime diaDeAbertura;
        public override void Atualizar(Comanda comanda)
        {
            quantidadeParaPagar = comanda.quantidadeParaPagar;
            garcom = comanda.garcom;
            mesa = comanda.mesa;
            pedido = comanda.pedido;
            listaDePedidos = comanda.listaDePedidos;
            EmAberto = comanda.EmAberto;
            diaDeAbertura = comanda.diaDeAbertura.Date;

        }
    }
}
