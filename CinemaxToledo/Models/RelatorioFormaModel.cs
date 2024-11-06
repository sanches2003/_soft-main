using Repositorio.Contexto;
using Repositorio.Entidades;
using Repositorio;

namespace CompusoftAtendimento.Models
{
    public class RelatorioFormaModel
    {
        public List<ViewTotalChamadosPorForma> listar() //nome da entidade do relatorio
        {
            List<ViewTotalChamadosPorForma> listamodel = null;

            using (SoftContexto contexto = new SoftContexto())
            {
                RepositorioChamadosForma repositorio =
                        new RepositorioChamadosForma(contexto);
                List<ViewTotalChamadosPorForma> lista = repositorio.ListarTodos().OrderByDescending(y => y.TotalChamados).ToList();
                listamodel = lista;
            }

            return listamodel;
        }
    }
}
