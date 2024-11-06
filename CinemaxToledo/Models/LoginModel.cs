using AutoMapper;
using Repositorio.Contexto;
using Repositorio.Entidades;
using Repositorio;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompusoftAtendimento.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Código")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "Usuário deve ter no máximo 30 caracteres!")]
        [MinLength(3, ErrorMessage = "Usuário deve ter no mínimo 3 caracteres!")]
        [Display(Name = "Usuário")]
        public String login { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(5, ErrorMessage = "Senha deve ter no máximo 5 caracteres!")]
        [MinLength(3, ErrorMessage = "Senha deve ter no mínimo 3 caracteres!")]
        [Display(Name = "Senha")]
        public String senha { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Usuário Administrador")]
        public bool ativo { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório! Selecione um cargo!")]
        [Display(Name = "Cargo")]
        public int idCargo { get; set; }

        public CargoModel? cargo { get; set; }

        public LoginModel validarLogin(string email, String senha){

            LoginModel model = null;
            using (SoftContexto contexto = new SoftContexto())

            {
                LoginRepositorio repositorio = 
                    new LoginRepositorio(contexto);
                Login usu =repositorio.Recuperar
                    (u=>u.login==email && u.senha==senha);
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                    model = mapper.Map<LoginModel>(usu);
            }
            return model;
        }

        public LoginModel salvar(LoginModel model)
        {
            
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            Login cat = mapper.Map<Login>(model);

            using (SoftContexto contexto = new SoftContexto())
            {
                LoginRepositorio repositorio =
                    new LoginRepositorio(contexto);

                if (model.id == 0)
                    repositorio.Inserir(cat);
                else
                    repositorio.Alterar(cat);

                contexto.SaveChanges();
            }
            model.id = cat.id;
            return model;
        }
        public List<LoginModel> listar()
        {
            List<LoginModel> listamodel = null;
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            using (SoftContexto contexto = new SoftContexto())
            {
                LoginRepositorio repositorio =
                    new LoginRepositorio(contexto);
                List<Login> lista = repositorio.ListarTodos();
                listamodel = mapper.Map<List<LoginModel>>(lista);
            }
            return listamodel;
        }

        public LoginModel selecionar(int id)
        {
            LoginModel model = null;
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            using (SoftContexto contexto = new SoftContexto())
            {
                LoginRepositorio repositorio =
                    new LoginRepositorio(contexto);
                repositorio.Recuperar(c => c.id == id);//select * from Login c 'onde' c.id = id
                Login cat = repositorio.Recuperar(c => c.id == id);
                model = mapper.Map<LoginModel>(cat);
            }
            return model;
        }

        public void excluir(int id)
        {
            using (SoftContexto contexto = new SoftContexto())
            {
                LoginRepositorio repositorio =
                    new LoginRepositorio(contexto);
                Login cat = repositorio.Recuperar(c => c.id == id);
                repositorio.Excluir(cat);
                contexto.SaveChanges();
            }
        }

        public bool PodeExcluir(int idUsuarioLogado, int idUsuarioParaExcluir)
        {
            return idUsuarioLogado != idUsuarioParaExcluir;
        }
    }
}
