using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smartgym.Models
{
    public class Conta
    {
        public Conta()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdConta { get; set;  }

        public long IdAlunoConta { get; set;  }

        [ForeignKey("IdAlunoConta")]
        public virtual Aluno AlunoConta { get; set; }

        public long IdProfessorConta { get; set; }

        [ForeignKey("IdProfessorConta")]
        public virtual Professor ProfessorConta { get; set; }

        [MinLength(4)]
        [MaxLength(60)]
        [Required(ErrorMessage = "Necessário adicionar um Email a Conta.")]
        public string EmailConta { get; set; }


        [MinLength(5)]
        [MaxLength(40)]
        [Required(ErrorMessage = "Necessário adicionar uma Senha a Conta.")]
        public string SenhaConta { get; set; }
    }
}