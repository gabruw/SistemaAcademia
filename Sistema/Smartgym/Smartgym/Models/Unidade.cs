using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smartgym.Models
{
    public class Unidade
    {
        public Unidade()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUnidade { get; set; }

        public int IdEnderecoUnidade { get; set; }

        [ForeignKey("IdEnderecoUnidade")]
        public virtual Endereco EnderecoUnidade { get; set; }

        public virtual ICollection<Professor> ProfessorUnidade { get; set; }

        [MinLength(1)]
        [MaxLength(120)]
        [Required(ErrorMessage = "Necessário adicionar um Nome a Unidade.")]
        public string NomeUnidade { get; set; }

        [MinLength(64)]
        [MaxLength(64)]
        [Required(ErrorMessage = "Necessário adicionar um Nome a Unidade.")]
        public string ImagemUnidade { get; set; }
    }
}