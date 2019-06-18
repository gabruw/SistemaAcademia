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
        public int IdAgenda { get; set; }

        public int IdProfessorAgenda { get; set; }

        [ForeignKey("IdProfessorAgenda")]
        public virtual Professor ProfessorAgenda { get; set; }

        public int IdAlunoAgenda { get; set; }

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