//using AspNetCore;
using AutoMapper;
using Repositorio;
using Repositorio.Contexto;
using Repositorio.Entidades;
using System.ComponentModel.DataAnnotations;

namespace CompusoftAtendimento.Models
{
    public class EmpresaModel
    {
        [Display(Name = "Código")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "Razão Social deve ter no máximo 30 caracteres!")]
        [MinLength(3, ErrorMessage = "Razão Social deve ter no mínimo 3 caracteres!")]
        [Display(Name = "Razão Social")] 
        public String razaosocial { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3, ErrorMessage = "CNPJ deve ter no mínimo 3 caracteres!")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "O CNPJ deve ter 14 dígitos.")]
        [Display(Name = "CNPJ")]
        public string cnpj { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "O Telefone deve ter 11 dígitos.")]
        [MinLength(3, ErrorMessage = "Telefone deve ter no mínimo 3 caracteres!")]
        [Display(Name = "Telefone")]
        public String telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "O Celular deve ter 11 dígitos.")]
        [MinLength(3, ErrorMessage = "Celular deve ter no mínimo 3 caracteres!")]
        [Display(Name = "Celular")]
        public String celular { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(20, ErrorMessage = "O e-mail deve ter no máximo 20 caracteres!")]
        [MinLength(3, ErrorMessage = "E-mail deve ter no mínimo 3 caracteres!")]
        [Display(Name = "E-mail")]
        public String email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3, ErrorMessage = "CEP deve ter no mínimo 3 caracteres!")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O CEP deve ter 8 dígitos.")]
        [Display(Name = "CEP")]
        public string cep { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(80, ErrorMessage = "Logradouro deve ter no máximo 80 caracteres!")]
        [MinLength(3, ErrorMessage = "Logradouro deve ter no mínimo 3 caracteres!")]
        [Display(Name = "Logradouro")]
        public String logradouro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(10, ErrorMessage = "Número deve ter no máximo 10 caracteres!")]
        [Display(Name = "Número")]
        public String numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "Bairro deve ter no máximo 30 caracteres!")]
        [MinLength(3, ErrorMessage = "Bairro deve ter no mínimo 3 caracteres!")]
        [Display(Name = "Bairro")]
        public String bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "Cidade deve ter no máximo 30 caracteres!")]
        [MinLength(3, ErrorMessage = "Cidade deve ter no mínimo 3 caracteres!")]
        [Display(Name = "Cidade")]
        public String cidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "Estado deve ter no máximo 30 caracteres!")]
        [Display(Name = "Estado")]
        public String estado { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(80, ErrorMessage = "Complemento deve ter no máximo 80 caracteres!")]
        [MinLength(3, ErrorMessage = "Complemento deve ter no mínimo 3 caracteres!")]
        [Display(Name = "Complemento")]
        public String complemento { get; set; }




        public EmpresaModel salvar(EmpresaModel model)
        {
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            Empresa cat = mapper.Map<Empresa>(model);

            using (SoftContexto contexto = new SoftContexto())
            {
                EmpresaRepositorio repositorio =
                new EmpresaRepositorio(contexto);

                if (model.id == 0)
                    repositorio.Inserir(cat);
                else
                    repositorio.Alterar(cat);

                contexto.SaveChanges();
            }
            model.id = cat.id;
            return model;


        }

        public List<EmpresaModel> listar()
        {
            List<EmpresaModel> listamodel = null;
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            using (SoftContexto contexto = new SoftContexto())
            {
                EmpresaRepositorio repositorio =
                    new EmpresaRepositorio(contexto);
                List<Empresa> lista = repositorio.ListarTodos();
                listamodel = mapper.Map<List<EmpresaModel>>(lista);
            }

            return listamodel;
        }

        public EmpresaModel selecionar(int id)
        {
            EmpresaModel model = null;
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            using (SoftContexto contexto = new SoftContexto())
            {
                EmpresaRepositorio repositorio =
                    new EmpresaRepositorio(contexto);
                //select * from categoria c where c.id = id
                Empresa cat = repositorio.Recuperar(c => c.id == id);
                model = mapper.Map<EmpresaModel>(cat);
            }
            return model;
        }

        public void excluir(int id)
        {

            using (SoftContexto contexto = new SoftContexto())
            {
                EmpresaRepositorio repositorio =
                    new EmpresaRepositorio(contexto);
                Empresa cat = repositorio.Recuperar(c => c.id == id);
                repositorio.Excluir(cat);
                contexto.SaveChanges();
            }
        }
    }
}
