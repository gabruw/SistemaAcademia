using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smartgym.Models
{
    public class Exercicio
    {
        public Exercicio()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdExercicio { get; set; }

        public int IdAparelhoExercicio { get; set; }

        [ForeignKey("IdAparelhoExercicio")]
        public virtual Exercicio AparelhoExercicio { get; set; }

        public int IdSerieExercicio { get; set; }

        [ForeignKey("IdSerieExercicio")]
        public virtual Serie SerieExercicio { get; set; }

        [MinLength(1)]
        [MaxLength(60)]
        [Required(ErrorMessage = "Necessário adicionar um Nme ao Exercício.")]
        public string NomeExercicio { get; set; }

        [MinLength(1)]
        [MaxLength(800)]
        [Required(ErrorMessage = "Necessário adicionar uma Observação ao Exercício.")]
        public string ObservacaoExercicio { get; set; }
    }
}
