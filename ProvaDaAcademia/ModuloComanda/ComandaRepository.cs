using ProvaDaAcademia.ClassesBase;


namespace ProvaDaAcademia.ModuloComanda
{
    internal class ComandaRepository : RepositoryBase<Comanda>
    {
        public ComandaRepository(List<Comanda> listaDeEntidades)
        {
            this.listaEntidades = listaDeEntidades;
        }
        public List<Comanda> RetornaComandasAbertas()
        {
            return listaEntidades.FindAll(c => c.EmAberto == true);
        }

        public override bool VerificaObjetosComErro(Comanda c)
        {
            if(c.mesa == null)
            {
                return true;
            }
            if (c.garcom == null)
            {
                return true;
            }
            return false;
        }
    }
}
