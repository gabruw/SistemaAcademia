using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTO
{
    public class Agenda : DTODefault
    {
        public Agenda()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdAgenda { get; set; }

        public long IdProfessorAgenda { get; set; }

        [ForeignKey("IdProfessorAgenda")]
        public virtual Professor ProfessorAgenda { get; set; }

        public long IdAlunoAgenda { get; set; }

        [ForeignKey("IdAlunoAgenda")]
        public virtual Aluno AlunoAgenda { get; set; }

        public DateTime DataAgenda { get; set; }

        public override void Validate()
        {
            ClearValidateMensages();

            if (DataAgenda.ToString().Length < 1)
            {
                AddError("O campo Data da Agenda não foi informado.");
            }
        }
    }
}