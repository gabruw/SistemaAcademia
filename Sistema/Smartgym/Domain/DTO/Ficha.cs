using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTO
{
    public class Ficha : DTODefault
    {
        public Ficha()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFicha { get; set; }

        public int IdProfessorFicha { get; set; }

        [ForeignKey("IdProfessorFicha")]
        public virtual Professor ProfessorFicha { get; set; }

        public int IdAlunoFicha { get; set; }

        [ForeignKey("IdAlunoFicha")]
        public virtual Aluno AlunoFicha { get; set; }

        public virtual ICollection<Serie> SerieFicha { get; set; }

        public override void Validate()
        {
            ClearValidateMensages();

            if (SerieFicha.Count < 1)
            {
                AddError("O campo Série da Ficha não foi informado.");
            }
        }
    }
}