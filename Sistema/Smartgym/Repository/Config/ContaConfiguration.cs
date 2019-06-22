using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class ContaConfiguration : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.HasKey(c => c.IdConta);

            builder.HasIndex(c => c.EmailConta).IsUnique().HasName("UniqueKey_EmailConta");
            builder.Property(c => c.SenhaConta).IsRequired().HasMaxLength(40).HasColumnType("varchar(40)");
        }
    }
}