using ProvaDaAcademia.ClassesBase;
using ProvaDaAcademia.ModuloMesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDaAcademia.ModuloProduto
{
    internal class Produto : EntidadeBase
    {
        public string nome;
        public double preco;
        public string tipo;

        public override void Atualizar(EntidadeBase entidadeAtualizada)
        {
            Produto produto = (Produto)entidadeAtualizada;
            nome = produto.nome;
            preco = produto.preco;
            tipo = produto.tipo;
        }

         
    }
}
