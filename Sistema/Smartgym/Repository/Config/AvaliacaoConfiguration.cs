using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class AvaliacaoConfiguration : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.HasKey(av => av.IdAvaliacao);

            builder.HasOne(av => av.AlunoAvaliacao).WithMany().HasForeignKey(av => av.IdAlunoAvaliacao);
            builder.HasOne(av => av.ProfessorAvaliacao).WithMany().HasForeignKey(av => av.IdProfessorAvaliacao);

            builder.Property(av => av.DataAvaliacao).IsRequired().HasColumnType("date");

            builder.Property(av => av.AlturaAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.PesoAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.ImcAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");

            builder.Property(av => av.BracoDireitoAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.BracoEsquerdoAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.PeitoralAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.AbdomemAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.QuadrilAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.QuadricepsDireitoAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.QuadrcepsEsquerdoAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.PanturrilhaDireitaAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.PanturrilhaEsquerdaAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.DobraCutaneaPeitoAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.DobraCutaneaCoxaAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.DobraCutaneaTricepsAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.DobraCutaneaAbdomemAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.DobraCutaneaQuadrilAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.DobraCutaneaPanturrilhaAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");
            builder.Property(av => av.PercentualGorduraAvaliacao).IsRequired().HasMaxLength(4).HasColumnType("decimal(2,2)");

            builder.Property(av => av.ObservacaoAvaliacao).IsRequired().HasMaxLength(800).HasColumnType("varchar(800)");
        }
    }
}