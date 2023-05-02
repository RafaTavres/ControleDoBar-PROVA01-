using ProvaDaAcademia.ClassesBase;
using ProvaDaAcademia.ModuloComanda;
using ProvaDaAcademia.ModuloMesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ModuloGarcom
{
    internal class Garcom : EntidadeBase
    {
        public string nome;
        public int CNPJ;

        public override void Atualizar(EntidadeBase entidadeAtualizada)
        {
            Garcom garcom = (Garcom)entidadeAtualizada;
            nome = garcom.nome;
            CNPJ = garcom.CNPJ;
        }
    }
}
