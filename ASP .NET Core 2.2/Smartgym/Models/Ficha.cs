using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smartgym.Models
{
    public class Ficha
    {
        public Ficha()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdFicha { get; set; }

        public long IdProfessorFicha { get; set; }

        [ForeignKey("IdProfessorFicha")]
        public virtual Professor ProfessorFicha { get; set; }

        public long IdAlunoFicha { get; set; }

        [ForeignKey("IdAlunoFicha")]
        public virtual Aluno AlunoFicha { get; set; }

        public virtual ICollection<Serie> SerieFicha { get; set; }
    }
}