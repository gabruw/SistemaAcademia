using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(en => en.IdEndereco);

            builder.Property(en => en.CepEndereco).IsRequired().HasMaxLength(8).HasColumnType("int(8)");
            builder.Property(en => en.RuaEndereco).IsRequired().HasMaxLength(80).HasColumnType("varchar(80)");
            builder.Property(en => en.BairroEndereco).IsRequired().HasMaxLength(80).HasColumnType("varchar(80)");
            builder.Property(en => en.NumeroEndereco).IsRequired().HasMaxLength(5).HasColumnType("int(5)");
            builder.Property(en => en.ComplementoEndereco).HasMaxLength(5).HasColumnType("int(5)");
        }
    }
}