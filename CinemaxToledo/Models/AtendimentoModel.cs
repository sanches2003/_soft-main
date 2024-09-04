using AutoMapper;
using Newtonsoft.Json.Linq;
using Repositorio;
using Repositorio.Contexto;
using Repositorio.Entidades;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace CompusoftAtendimento.Models
{
    public class AtendimentoModel
    {
        [Display(Name = "Código")]
        public int id { get; set; }

        [Display(Name = "Contato")]
        public String Contato { get; set; }


        [Display(Name = "Data e Hora")]
        public String DataHora { get; set; }


        [Display(Name = "Descricao")]
        public String Descricao { get; set; }


        [Display(Name = "Anexo")]
        public String Anexo { get; set; }


        [Display(Name = "Descrição Solução")]
        public String DescricaoSolucao { get; set; }


        [Display(Name = "Telefone")]
        public String Telefone { get; set; }

        //FKs
        [Display(Name = "Categoria do Problema")]
        public int idCategoriaProblema { get; set; }
        public CategoriaProblemaModel? categoriaproblema { get; set; }


        [Display(Name = "Empresa")]
        public int idEmpresa { get; set; }
        public EmpresaModel? empresa { get; set; }


        [Display(Name = "Plataforma")]
        public int idPlataforma { get; set; }
        public PlataformaModel? plataforma { get; set; }


        [Display(Name = "Forma de Atendimento")]
        public int idFormaAtendimento { get; set; }
        public FormaAtendimentoModel? formaatendimento { get; set; }


        [Display(Name = "Status")]
        public int idStatus { get; set; }
        public StatusModel? status { get; set; }


        [Display(Name = "Pendência")]
        public int idPendencia { get; set; }
        public PendenciaModel? pendencias { get; set; }


        [Display(Name = "Usuário")]
        public int idUsuario { get; set; }
        public LoginModel? usuario { get; set; }

        public AtendimentoModel salvar(AtendimentoModel model)
        {
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            Atendimento cat = mapper.Map<Atendimento>(model);

            using (SoftContexto contexto = new SoftContexto())
            { 
                AtendimentoRepositorio repositorio =
                    new AtendimentoRepositorio(contexto);

                if (model.id == 0)
                    repositorio.Inserir(cat);
                else
                    repositorio.Alterar(cat);

                contexto.SaveChanges();
            }
            model.id = cat.id;
            return model;
        }

        public List<AtendimentoModel> listar()
        {
            List<AtendimentoModel> listamodel = null;
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            using (SoftContexto contexto = new SoftContexto())
            {
                AtendimentoRepositorio repositorio =
                    new AtendimentoRepositorio(contexto);
                List<Atendimento> lista = repositorio.ListarTodos();
                listamodel = mapper.Map<List<AtendimentoModel>>(lista);
            }
            return listamodel;
        }

        public AtendimentoModel selecionar(int id)
        {
            AtendimentoModel model = null;
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            using (SoftContexto contexto = new SoftContexto())
            {
                AtendimentoRepositorio repositorio =
                    new AtendimentoRepositorio(contexto);
                repositorio.Recuperar(c => c.id == id);//select * from Login c 'onde' c.id = id
                Atendimento cat = repositorio.Recuperar(c => c.id == id);
                model = mapper.Map<AtendimentoModel>(cat);
            }
            return model;
        }

        public void excluir(int id)
        {
            using (SoftContexto contexto = new SoftContexto())
            {
                AtendimentoRepositorio repositorio =
                    new AtendimentoRepositorio(contexto);
                Atendimento cat = repositorio.Recuperar(c => c.id == id);
                repositorio.Excluir(cat);
                contexto.SaveChanges();
            }
        }
    }
}

