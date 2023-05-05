using ProvaDaAcademia.ClassesBase;
using ProvaDaAcademia.ModuloComanda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
