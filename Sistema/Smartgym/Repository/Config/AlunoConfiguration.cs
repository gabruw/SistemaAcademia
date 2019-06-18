using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Config
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(al => al.IdAluno);

            builder.HasMany(al => al.FichaAluno).WithOne(fc => fc.AlunoFicha).HasForeignKey(fc => fc.IdFicha);
            builder.HasMany(al => al.AvaliacaoAluno).WithOne(fc => fc.AlunoAvaliacao).HasForeignKey(fc => fc.IdAvaliacao);

            builder.Property(al => al.PermissaoAluno).IsRequired().HasMaxLength(1).HasColumnType("int(1)");
            builder.Property(al => al.EmailAluno).IsRequired().HasMaxLength(60).HasColumnType("varchar(60)");
            builder.Property(al => al.SenhaAluno).IsRequired().HasMaxLength(40).HasColumnType("varchar(40)");

            builder.Property(al => al.MatriculaAluno).IsRequired().HasMaxLength(8).HasColumnType("varchar(8)");
            builder.Property(al => al.NomeAluno).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(al => al.CpfAluno).IsRequired().HasMaxLength(11).HasColumnType("varchar(11)");
            builder.Property(al => al.DataNascimentoAluno).IsRequired().HasColumnType("date");
            builder.Property(al => al.TelefoneAluno).HasMaxLength(11).HasColumnType("int(11)");
            builder.Property(al => al.CelularAluno).HasMaxLength(11).HasColumnType("int(11)");
            builder.Property(al => al.SexoAluno).IsRequired().HasMaxLength(1).HasColumnType("int(1)");

            builder.Property(al => al.CepAluno).IsRequired().HasMaxLength(8).HasColumnType("int(8)");
            builder.Property(al => al.RuaEnderecoAluno).IsRequired().HasMaxLength(80).HasColumnType("varchar(80)");
            builder.Property(al => al.BairroEnderecoAluno).IsRequired().HasMaxLength(80).HasColumnType("varchar(80)");
            builder.Property(al => al.NumeroEnderecoAluno).IsRequired().HasMaxLength(5).HasColumnType("int(5)");
            builder.Property(al => al.ComplementoEnderecoAluno).HasMaxLength(5).HasColumnType("int(5)");

            builder.Property(al => al.ImagemAluno).HasMaxLength(64).HasColumnType("varchar(64)");
        }
    }
}