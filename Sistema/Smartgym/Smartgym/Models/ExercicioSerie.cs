using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smartgym.Models
{
    public class ExercicioSerie
    {
        public ExercicioSerie()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdExercicioSerie { get; set; }

        public long IdExercicioExercicioSerie { get; set; }

        [ForeignKey("IdExercicioExercicioSerie")]
        public virtual Exercicio ExercicioExercicioSerie { get; set; }

        public long IdSerieExercicioSerie { get; set; }

        [ForeignKey("IdSerieExercicioSerie")]
        public virtual Serie SerieExercicioSerie { get; set; }

        public int RepeticoesExercicioSerie { get; set; }
    }
}