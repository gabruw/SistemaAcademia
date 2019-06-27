using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTO
{
    public class Serie : DTODefault
    {
        public Serie()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdSerie { get; set; }

        public long IdFichaSerie { get; set; }

        [ForeignKey("IdFichaSerie")]
        public virtual Ficha FichaSerie { get; set; }

        public virtual ICollection<ExercicioSerie> ExercicioExercicioSerie { get; set; }

        public string NomeSerie { get; set; }

        public string ObservacaoSerie { get; set; }

        public int RepeticoesSerie { get; set; }

        public override void Validate()
        {
            ClearValidateMensages();

            if (ExercicioExercicioSerie.Count < 1)
            {
                AddError("O campo Exercício da Série não foi informado.");
            }

            if (NomeSerie.Length < 1)
            {
                AddError("O campo Nome da Série não foi informado.");
            }
        }
    }
}