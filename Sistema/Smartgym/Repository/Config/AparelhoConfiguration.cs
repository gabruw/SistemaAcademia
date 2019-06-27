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

            builder.HasIndex(ap => ap.NomeAparelho).IsUnique();
        }
    }
}