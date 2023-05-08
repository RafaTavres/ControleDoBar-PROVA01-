using ProvaDaAcademia.ClassesBase;


namespace ProvaDaAcademia.ModuloGarcom
{
    internal class GarcomRepository : RepositoryBase<Garcom>
    {
        public GarcomRepository(List<Garcom> listaDeEntidades) 
        {
            this.listaEntidades = listaDeEntidades;
        }

        public override bool VerificaObjetosComErro(Garcom entidade)
        {
            return false;
        }
    }
}
