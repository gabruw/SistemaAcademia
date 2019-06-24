using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class SerieConfiguration : IEntityTypeConfiguration<Serie>
    {
        public void Configure(EntityTypeBuilder<Serie> builder)
        {
            builder.HasKey(s => s.IdSerie);

            builder.HasOne(s => s.FichaSerie).WithMany().HasForeignKey(fc => fc.IdFichaSerie);
            builder.HasMany(s => s.ExercicioSerie).WithOne(e => e.SerieExercicio).HasForeignKey(p => p.IdExercicio);

            builder.Property(s => s.NomeSerie).IsRequired().HasMaxLength(60).HasColumnType("varchar(60)");
            builder.Property(s => s.ObservacaoSerie).HasMaxLength(800).HasColumnType("varchar(800)");
            builder.Property(s => s.RepeticoesSerie).HasMaxLength(2).HasColumnType("int");
        }
    }
}