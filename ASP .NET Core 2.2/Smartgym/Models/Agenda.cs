using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smartgym.Models
{
    public class Agenda
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
    }
}