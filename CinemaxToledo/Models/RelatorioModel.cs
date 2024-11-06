using AutoMapper;
using Repositorio.Contexto;
using Repositorio.Entidades;
using Repositorio;

namespace CompusoftAtendimento.Models
{
    public class RelatorioModel
    {

        public List<ViewTotalChamados> listar() //nome da entidade do relatorio
        {
            List<ViewTotalChamados> listamodel = null;

            using (SoftContexto contexto = new SoftContexto())
            {
                RepositorioTotalChamados repositorio =
                        new RepositorioTotalChamados(contexto);
                List<ViewTotalChamados> lista = repositorio.ListarTodos().OrderByDescending(y=>y.TotalChamados).ToList();
                listamodel = lista;
            }

            return listamodel;
        }


    }
}
