using Repositorio.Contexto;
using Repositorio.Entidades;
using Repositorio;

namespace CompusoftAtendimento.Models
{
    public class RelatorioAgenteModel
    {

        public List<ViewTotalChamadosPorUsuario> listar() //nome da entidade do relatorio
        {
            List<ViewTotalChamadosPorUsuario> listamodel = null;

            using (SoftContexto contexto = new SoftContexto())
            {
                RepositorioChamadosUsuario repositorio =
                        new RepositorioChamadosUsuario(contexto);
                List<ViewTotalChamadosPorUsuario> lista = repositorio.ListarTodos().OrderByDescending(y => y.TotalChamados).ToList();
                listamodel = lista;
            }

            return listamodel;
        }
    }
}
