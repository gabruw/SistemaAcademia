using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smartgym.Models
{
    public class Serie
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

        [MinLength(1)]
        [MaxLength(60)]
        [Required(ErrorMessage = "Necessário adicionar um Nome a Série.")]
        public string NomeSerie { get; set; }

        [MinLength(1)]
        [MaxLength(800)]
        [Required(ErrorMessage = "Necessário adicionar uma Observação a Série.")]
        public string ObservacaoSerie { get; set; }

        [MinLength(1)]
        [MaxLength(3)]
        [Required(ErrorMessage = "Necessário adicionar um número de Repetições a Série.")]
        public string RepeticoesSerie { get; set; }
    }
}