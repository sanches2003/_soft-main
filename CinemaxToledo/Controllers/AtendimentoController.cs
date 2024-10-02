using CompusoftAtendimento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Drawing;

namespace CompusoftAtendimento.Controllers
{
    public class AtendimentoController : Controller
    {
        public IActionResult cadastro()
        {

            ViewBag.listacategoriaproblemas = (new CategoriaProblemaModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.descricao
            });

            ViewBag.listaempresas = (new EmpresaModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.razaosocial
            });

            ViewBag.listaplataformas = (new PlataformaModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.descricao
            });

            ViewBag.listaformaatendimentos = (new FormaAtendimentoModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.descricao
            });

            ViewBag.listastatus = (new StatusModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.descricao
            });

            ViewBag.listausuarios = (new LoginModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.login
            });

            ViewBag.cadastro = new AtendimentoModel();

            AtendimentoModel catModel = new AtendimentoModel();
            List<AtendimentoModel> lista = catModel.listar();
            return View(lista); //passando a lista por parametro para a view 
        }

        [HttpPost]
        public IActionResult salvar(AtendimentoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AtendimentoModel catmodel = new AtendimentoModel();
                    catmodel.salvar(model);
                    ViewBag.mensagem = "Dados salvos com sucesso!";
                    ViewBag.classe = "alert-success";
                }
                catch (Exception ex)
                {
                    ViewBag.mensagem = "ops... Erro ao salvar!" + ex.Message + "/" + ex.InnerException;
                    ViewBag.classe = "alert-danger";
                }
            }
            return RedirectToAction("cadastro");
        }


        [HttpPost]
        public IActionResult salvaralterar(AtendimentoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AtendimentoModel catmodel = new AtendimentoModel();
                    catmodel.salvar(model);
                    ViewBag.mensagem = "Dados salvos com sucesso!";
                    ViewBag.classe = "alert-success";
                }
                catch (Exception ex)
                {
                    ViewBag.mensagem = "ops... Erro ao salvar!" + ex.Message + "/" + ex.InnerException;
                    ViewBag.classe = "alert-danger";
                }
            }
            return RedirectToAction("listar");
        }

        public IActionResult listar()
        {
            AtendimentoModel catModel = new AtendimentoModel();
            List<AtendimentoModel> lista = catModel.listar();
            return View(lista); //passando a lista por parametro para a view 
        }

        public IActionResult prealterar(int id)
        {

            ViewBag.listacategoriaproblemas = (new CategoriaProblemaModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.descricao
            });

            ViewBag.listaempresas = (new EmpresaModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.razaosocial
            });

            ViewBag.listaplataformas = (new PlataformaModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.descricao
            });

            ViewBag.listaformaatendimentos = (new FormaAtendimentoModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.descricao
            });

            ViewBag.listastatus = (new StatusModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.descricao
            });

            ViewBag.listausuarios = (new LoginModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.login
            });

            AtendimentoModel model = new AtendimentoModel();
            ViewBag.cadastro =  model.selecionar(id);
            AtendimentoModel catModel = new AtendimentoModel();
            List<AtendimentoModel> lista = catModel.listar();
            return View("cadastro", lista); //passando a lista por parametro para a view 
        }

        public IActionResult alterar(int id)
        {

            ViewBag.listacategoriaproblemas = (new CategoriaProblemaModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.descricao
            });

            ViewBag.listaempresas = (new EmpresaModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.razaosocial
            });

            ViewBag.listaplataformas = (new PlataformaModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.descricao
            });

            ViewBag.listaformaatendimentos = (new FormaAtendimentoModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.descricao
            });

            ViewBag.listastatus = (new StatusModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.descricao
            });

            ViewBag.listausuarios = (new LoginModel()).listar().Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.login
            });


            AtendimentoModel model = new AtendimentoModel();
            ViewBag.alterar = model.selecionar(id);
            return View("alterar", model.selecionar(id));
        }

        public IActionResult excluir(int id)
        {
            AtendimentoModel model = new AtendimentoModel();
            try
            {
                model.excluir(id);
                ViewBag.mensagem = "Dados excluídos com sucesso!";
                ViewBag.classe = "alert-success";
            }
            catch (Exception ex)
            {
                ViewBag.mensagem = "Ops... Não foi possível excluir!" + ex.Message;
                ViewBag.classe = "alert-danger";
            }
            return View("cadastro", model.listar());
        }
    }
}

