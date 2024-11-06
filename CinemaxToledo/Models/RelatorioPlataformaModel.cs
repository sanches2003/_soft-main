using Repositorio.Contexto;
using Repositorio.Entidades;
using Repositorio;

namespace CompusoftAtendimento.Models
{
    public class RelatorioPlataformaModel
    {
        public List<ViewTotalChamadosPorPlataforma> listar() //nome da entidade do relatorio
        {
            List<ViewTotalChamadosPorPlataforma> listamodel = null;

            using (SoftContexto contexto = new SoftContexto())
            {
                RepositorioChamadosPlataforma repositorio =
                        new RepositorioChamadosPlataforma(contexto);
                List<ViewTotalChamadosPorPlataforma> lista = repositorio.ListarTodos().OrderByDescending(y => y.TotalChamados).ToList();
                listamodel = lista;
            }

            return listamodel;
        }
    }
}
