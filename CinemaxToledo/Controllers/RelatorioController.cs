using CompusoftAtendimento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositorio.Entidades;

namespace CompusoftAtendimento.Controllers
{
        public class RelatorioController : Controller
        {
            public IActionResult menu()
            {
                return View(); //passando a lista por parametro para a view
            }
            public IActionResult agentes()
            {
            RelatorioAgenteModel catModel = new RelatorioAgenteModel();
            List<ViewTotalChamadosPorUsuario> lista = catModel.listar();
            return View(lista); //passando a lista por parametro para a view
            }
            public IActionResult categoriadoproblema()
            {
            RelatorioCategoriaModel catModel = new RelatorioCategoriaModel();
            List<ViewTotalChamadosPorCategoria> lista = catModel.listar();
            return View(lista); //passando a lista por parametro para a view
            }
            public IActionResult plataformas()
            {
            RelatorioPlataformaModel catModel = new RelatorioPlataformaModel();
            List<ViewTotalChamadosPorPlataforma> lista = catModel.listar();
            return View(lista); //passando a lista por parametro para a view
            }

            public IActionResult empresas()
            {
            RelatorioModel catModel = new RelatorioModel();
            List<ViewTotalChamados> lista = catModel.listar();
            return View(lista); //passando a lista por parametro para a view

            }

            public IActionResult formasdeatendimento()
                {
                RelatorioFormaModel catModel = new RelatorioFormaModel();
                List<ViewTotalChamadosPorForma> lista = catModel.listar();
                return View(lista); //passando a lista por parametro para a view
            }
        }
}
