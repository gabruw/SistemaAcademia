using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class UnidadeConfiguration : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder.HasKey(u => u.IdUnidade);

            builder.HasOne(u => u.EnderecoUnidade).WithMany().HasForeignKey(u => u.IdEnderecoUnidade);

            builder.HasMany(u => u.ProfessorUnidade).WithOne(p => p.UnidadeProfessor).HasForeignKey(p => p.IdProfessor);

            builder.Property(u => u.NomeUnidade).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(u => u.ImagemUnidade).IsRequired().HasMaxLength(64).HasColumnType("varchar(64)");
        }
    }
}