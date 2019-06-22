using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(p => p.IdProfessor);

            builder.HasOne(p => p.ContaProfessor).WithMany().HasForeignKey(p => p.IdContaProfessor);
            builder.HasOne(p => p.EnderecoProfessor).WithMany().HasForeignKey(p => p.IdEnderecoProfessor);

            builder.HasOne(p => p.UnidadeProfessor).WithMany().HasForeignKey(p => p.IdUnidadeProfessor);
            builder.HasOne(p => p.AgendaProfessor).WithMany().HasForeignKey(p => p.IdAgendaProfessor);

            builder.Property(p => p.PermissaoProfessor).IsRequired().HasMaxLength(1).HasColumnType("int(1)");

            builder.HasIndex(p => p.CrefProfessor).IsUnique().HasName("AlternateKey_CrefProfessor");
            builder.Property(p => p.NomeProfessor).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.HasIndex(p => p.CpfProfessor).IsUnique().HasName("AlternateKey_CpfProfessor");
            builder.Property(p => p.DataNascimentoProfessor).IsRequired().HasColumnType("date");
            builder.Property(p => p.DataAdmissaoProfessor).IsRequired().HasColumnType("date");
            builder.Property(p => p.TelefoneProfessor).HasMaxLength(10).HasColumnType("bigint");
            builder.Property(p => p.CelularProfessor).HasMaxLength(11).HasColumnType("bigint");
            builder.Property(p => p.SexoProfessor).IsRequired().HasMaxLength(1).HasColumnType("int(1)");

            builder.Property(p => p.ImagemProfessor).HasMaxLength(200).HasColumnType("varchar(200)");
        }
    }
}