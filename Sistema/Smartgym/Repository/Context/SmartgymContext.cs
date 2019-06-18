using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Repository.Config;

namespace Repository.Context
{
    public class SmartgymContext : DbContext
    {
        public SmartgymContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Agenda>();
            modelBuilder.Ignore<Aluno>();
            modelBuilder.Ignore<Aparelho>();
            modelBuilder.Ignore<Avaliacao>();
            modelBuilder.Ignore<Endereco>();
            modelBuilder.Ignore<Exercicio>();
            modelBuilder.Ignore<Ficha>();
            modelBuilder.Ignore<Professor>();
            modelBuilder.Ignore<Serie>();
            modelBuilder.Ignore<Unidade>();

            modelBuilder.ApplyConfiguration(new AgendaConfiguration());
            modelBuilder.ApplyConfiguration(new AlunoConfiguration());
            modelBuilder.ApplyConfiguration(new AparelhoConfiguration());
            modelBuilder.ApplyConfiguration(new AvaliacaoConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new ExercicioConfiguration());
            modelBuilder.ApplyConfiguration(new FichaConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new SerieConfiguration());
            modelBuilder.ApplyConfiguration(new UnidadeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Agenda> Agenda { get; set; }

        public DbSet<Aluno> Aluno { get; set; }

        public DbSet<Aparelho> Aparelho { get; set; }

        public DbSet<Avaliacao> Avaliacao { get; set; }

        public DbSet<Endereco> Endereco { get; set; }

        public DbSet<Exercicio> Exercicio { get; set; }

        public DbSet<Ficha> Ficha { get; set; }

        public DbSet<Professor> Professor { get; set; }

        public DbSet<Serie> Serie { get; set; }

        public DbSet<Unidade> Unidade { get; set; }
    }
}