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
                return View(); //passando a lista por parametro para a view
            }
            public IActionResult categoriadoproblema()
            {
                return View(); //passando a lista por parametro para a view
            }
            public IActionResult plataformas()
            {
                return View(); //passando a lista por parametro para a view
            }

            public IActionResult empresas()
            {
            RelatorioModel catModel = new RelatorioModel();
            List<ViewTotalChamados> lista = catModel.listar();
            return View(lista); //passando a lista por parametro para a view

            }

        public IActionResult formasdeatendimento()
            {
                return View(); //passando a lista por parametro para a view
            }
    }
}
