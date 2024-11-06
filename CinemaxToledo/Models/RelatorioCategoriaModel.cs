using Repositorio.Contexto;
using Repositorio.Entidades;
using Repositorio;

namespace CompusoftAtendimento.Models
{
    public class RelatorioCategoriaModel
    {
        public List<ViewTotalChamadosPorCategoria> listar() //nome da entidade do relatorio
        {
            List<ViewTotalChamadosPorCategoria> listamodel = null;

            using (SoftContexto contexto = new SoftContexto())
            {
                RepositorioChamadosCategoria repositorio =
                        new RepositorioChamadosCategoria(contexto);
                List<ViewTotalChamadosPorCategoria> lista = repositorio.ListarTodos().OrderByDescending(y => y.TotalChamados).ToList();
                listamodel = lista;
            }

            return listamodel;
        }
    }
}
