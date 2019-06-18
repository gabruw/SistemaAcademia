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
        public int IdSerie { get; set; }

        public int IdFichaSerie { get; set; }

        [ForeignKey("IdFichaSerie")]
        public virtual Ficha FichaSerie { get; set; }

        public virtual ICollection<Exercicio> ExercicioSerie { get; set; }

        [MinLength(1)]
        [MaxLength(60)]
        [Required(ErrorMessage = "Necessário adicionar um Nome a Série.")]
        public string NomeSerie { get; set; }

        [MinLength(1)]
        [MaxLength(800)]
        [Required(ErrorMessage = "Necessário adicionar uma Observação a Série.")]
        public string ObservacaoSerie { get; set; }
    }
}