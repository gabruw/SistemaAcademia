using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class AgendaConfiguration : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.HasKey(ag => ag.IdAgenda);

            builder.HasOne(ag => ag.ProfessorAgenda).WithMany().HasForeignKey(p => p.IdProfessorAgenda);
            builder.HasOne(ag => ag.AlunoAgenda).WithMany().HasForeignKey(p => p.IdAlunoAgenda);

            builder.HasIndex(ag => ag.DataAgenda).IsUnique().HasName("UniqueKey_DataAgenda");
        }
    }
}