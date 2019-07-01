using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class FichaConfiguration : IEntityTypeConfiguration<Ficha>
    {
        public void Configure(EntityTypeBuilder<Ficha> builder)
        {
            builder.HasKey(fc => fc.IdFicha);

            builder.HasOne(fc => fc.ProfessorFicha).WithMany().HasForeignKey(fc => fc.IdProfessorFicha);
            builder.HasOne(fc => fc.AlunoFicha).WithMany().HasForeignKey(fc => fc.IdAlunoFicha);

            builder.HasMany(fc => fc.SerieFicha).WithOne(s => s.FichaSerie).HasForeignKey(p => p.IdSerie);
        }
    }
}