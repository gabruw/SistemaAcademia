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
        public int IdAgenda { get; set; }

        public int IdProfessorAgenda { get; set; }

        [ForeignKey("IdProfessorAgenda")]
        public virtual Professor ProfessorAgenda { get; set; }

        public int IdAlunoAgenda { get; set; }

        [ForeignKey("IdAlunoAgenda")]
        public virtual Aluno AlunoAgenda { get; set; }

        public DateTime DataAgenda { get; set; }
    }
}