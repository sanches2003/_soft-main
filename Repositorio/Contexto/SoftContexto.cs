using Microsoft.EntityFrameworkCore;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Contexto
{
    public class SoftContexto : DbContext

    {
        public SoftContexto()
        {
            //Criar ou atualizar o banco de dados
            this.Database.EnsureCreated();
        }

        public DbSet<Plataforma> plataformas { get; set; }

        public DbSet<FormaAtendimento> formaatendimento { get; set; }

        public DbSet<Login> login { get; set; }

        public DbSet<CategoriaProblema> categoriasproblemas { get; set; }

        public DbSet<Cargo> cargo { get; set; }

        public DbSet<Empresa> empresa { get; set; }

        public DbSet<Status> status { get; set; }


        //Não sei o que é isso:
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //var stringConexao = @"Server=JULIA;Database=Atendimento9;Integrated Security=true;Trust Server Certificate=true;";



            var stringConexao = @"Server=FELIPE_SANCHES;DataBase=_compusoftatendimento3;integrated security=true;Trust Server Certificate=true";
            //var stringConexao = @"Server=sql8005.site4now.net;DataBase=db_a98978_felipesanches;user id=db_a98978_felipesanches_admin;password=felipe98767";

            if (!optionsBuilder.IsConfigured)
          
            {
                optionsBuilder.UseSqlServer(stringConexao);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plataforma>(entidade =>
            {
                entidade.HasKey(e => e.id);// definindo: chave primaria
                entidade.Property(e => e.descricao).HasMaxLength(30);//qtd max caracteres
            });

            modelBuilder.Entity<FormaAtendimento>(entidade =>
            {
                entidade.HasKey(e => e.id);// definindo: chave primaria
                entidade.Property(e => e.descricao).HasMaxLength(30);//qtd max caracteres
            });
           
            modelBuilder.Entity<CategoriaProblema>(entidade =>
            {
                entidade.HasKey(e => e.id);
                entidade.Property(e => e.descricao).HasMaxLength(30);

            });

            modelBuilder.Entity<Status>(entidade => {
                entidade.HasKey(e => e.id);//chave primaria
                //qtde max caracteres
                entidade.Property(e => e.descricao).HasMaxLength(150);

            });


            modelBuilder.Entity<Cargo>(entidade => {
                entidade.HasKey(e => e.id);
                entidade.Property(e => e.descricao).HasMaxLength(30);               
    
            });

            modelBuilder.Entity<Empresa>(entidade =>
            {
                entidade.HasKey(e => e.id);
                entidade.Property(e => e.razaosocial).HasMaxLength(30);
                entidade.Property(e => e.cnpj).HasMaxLength(20);
                entidade.Property(e => e.telefone).HasMaxLength(20);
                entidade.Property(e => e.celular).HasMaxLength(20);
                entidade.Property(e => e.email).HasMaxLength(150);
                entidade.Property(e => e.cep).HasMaxLength(150);
                entidade.Property(e => e.logradouro).HasMaxLength(80);
                entidade.Property(e => e.numero).HasMaxLength(20);
                entidade.Property(e => e.bairro).HasMaxLength(30);
                entidade.Property(e => e.cidade).HasMaxLength(30);
                entidade.Property(e => e.estado).HasMaxLength(30);
                entidade.Property(e => e.complemento).HasMaxLength(80);

            });

            modelBuilder.Entity<Login>(entidade => {
                entidade.HasKey(e => e.id);
                entidade.Property(e => e.login).HasMaxLength(150);
                entidade.Property(e => e.senha).HasMaxLength(150);
                entidade.Property(e => e.ativo);
                //criando uma relação: (filme só tem 1 categoria:
                entidade.HasOne(e => e.cargo) //o lado da rel. que tem Um
                .WithMany(c => c.usuarios) //o lado da rel. que tem Muitos
                .HasForeignKey(e => e.idCargo) //prop chave estrangeira
                .HasConstraintName("FK_Login_Cargo") //nome do relacionamento
                .OnDelete(DeleteBehavior.NoAction); //configuração da exclusao
            });
        }

    }
}
