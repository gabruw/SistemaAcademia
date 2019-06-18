using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class AparelhoConfiguration : IEntityTypeConfiguration<Aparelho>
    {
        public void Configure(EntityTypeBuilder<Aparelho> builder)
        {
            builder.HasKey(ap => ap.IdAparelho);

            builder.Property(ap => ap.NomeAparelho).IsRequired().HasMaxLength(60).HasColumnType("varchar(60)");
        }
    }
}