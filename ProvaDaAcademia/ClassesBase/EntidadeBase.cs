

namespace ProvaDaAcademia.ClassesBase
{
    internal abstract class EntidadeBase<Te>
    {
        public int id { get; set; }
        public abstract void Atualizar(Te entidadeAtualizada);

    }
}
