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

            builder.HasOne(c => c.AlunoConta).WithMany().HasForeignKey(c => c.IdAlunoConta);
            builder.HasOne(c => c.ProfessorConta).WithMany().HasForeignKey(c => c.IdProfessorConta);

            builder.Property(c => c.EmailConta).IsRequired().HasMaxLength(60).HasColumnType("varchar(60)");
            builder.Property(c => c.SenhaConta).IsRequired().HasMaxLength(40).HasColumnType("varchar(40)");
        }
    }
}