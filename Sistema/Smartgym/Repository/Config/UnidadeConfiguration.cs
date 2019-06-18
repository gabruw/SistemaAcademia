using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    class UnidadeConfiguration : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder.HasKey(u => u.IdUnidade);

            builder.HasMany(u => u.ProfessorUnidade).WithOne(p => p.UnidadeProfessor).HasForeignKey(p => p.IdProfessor);

            builder.Property(u => u.CepUnidade).IsRequired().HasMaxLength(8).HasColumnType("int(8)");
            builder.Property(u => u.RuaEnderecoUnidade).IsRequired().HasMaxLength(80).HasColumnType("varchar(80)");
            builder.Property(u => u.BairroEnderecoUnidade).IsRequired().HasMaxLength(80).HasColumnType("varchar(80)");
            builder.Property(u => u.NumeroEnderecoUnidade).IsRequired().HasMaxLength(5).HasColumnType("int(5)");
            builder.Property(u => u.ComplementoEnderecoUnidade).HasMaxLength(5).HasColumnType("int(5)");
        }
    }
}