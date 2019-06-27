using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config 
{
    public class ExercicioSerieConfiguration : IEntityTypeConfiguration<ExercicioSerie>
    {
        public void Configure(EntityTypeBuilder<ExercicioSerie> builder)
        {
            builder.HasKey(es => es.IdExercicioSerie);

            builder.HasOne(es => es.ExercicioExercicioSerie).WithMany().HasForeignKey(ex => ex.IdExercicioExercicioSerie);
            builder.HasOne(es => es.SerieExercicioSerie).WithMany().HasForeignKey(ex => ex.IdSerieExercicioSerie);

            builder.Property(es => es.RepeticoesExercicioSerie).IsRequired().HasMaxLength(3).HasColumnType("int(3)");
        }
    }
}