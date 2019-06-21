using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(al => al.IdAluno);

            builder.HasOne(p => p.ContaAluno).WithMany().HasForeignKey(p => p.IdContaAluno);
            builder.HasOne(al => al.EnderecoAluno).WithMany().HasForeignKey(al => al.IdEnderecoAluno);

            builder.HasMany(al => al.FichaAluno).WithOne(fc => fc.AlunoFicha).HasForeignKey(fc => fc.IdFicha);
            builder.HasMany(al => al.AvaliacaoAluno).WithOne(fc => fc.AlunoAvaliacao).HasForeignKey(fc => fc.IdAvaliacao);

            builder.Property(al => al.PermissaoAluno).IsRequired().HasMaxLength(1).HasColumnType("int(1)");

            builder.Property(al => al.MatriculaAluno).IsRequired().HasMaxLength(8).HasColumnType("varchar(8)");
            builder.Property(al => al.NomeAluno).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(al => al.CpfAluno).IsRequired().HasMaxLength(11).HasColumnType("bigint");
            builder.Property(al => al.DataNascimentoAluno).IsRequired().HasColumnType("date");
            builder.Property(al => al.TelefoneAluno).HasMaxLength(10).HasColumnType("int(10)");
            builder.Property(al => al.CelularAluno).HasMaxLength(11).HasColumnType("bigint");
            builder.Property(al => al.SexoAluno).IsRequired().HasMaxLength(1).HasColumnType("int(1)");

            builder.Property(al => al.ImagemAluno).HasMaxLength(200).HasColumnType("varchar(200)");
        }
    }
}