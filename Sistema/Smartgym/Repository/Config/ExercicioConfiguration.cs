using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config 
{
    public class ExercicioConfiguration : IEntityTypeConfiguration<Exercicio>
    {
        public void Configure(EntityTypeBuilder<Exercicio> builder)
        {
            builder.HasKey(ex => ex.IdExercicio);

            builder.HasOne(ex => ex.AparelhoExercicio).WithMany().HasForeignKey(ex => ex.IdAparelhoExercicio);

            builder.Property(ex => ex.NomeExercicio).IsRequired().HasMaxLength(60).HasColumnType("varchar(60)");
            builder.Property(ex => ex.ObservacaoExercicio).IsRequired().HasMaxLength(800).HasColumnType("varchar(800)");
        }
    }
}