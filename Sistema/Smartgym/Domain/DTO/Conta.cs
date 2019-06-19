using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTO
{
    public class Conta : DTODefault
    {
        public Conta()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConta { get; set;  }

        public int IdAlunoConta { get; set;  }

        [ForeignKey("IdAlunoConta")]
        public virtual Aluno AlunoConta { get; set; }

        public int IdProfessorConta { get; set; }

        [ForeignKey("IdProfessorConta")]
        public virtual Professor ProfessorConta { get; set; }

        public string EmailConta { get; set; }

        public string SenhaConta { get; set; }

        public override void Validate()
        {
            ClearValidateMensages();


            if (EmailConta.Length < 1)
            {
                AddError("O campo Email da Conta não foi informado.");
            }

            if (SenhaConta.Length < 1)
            {
                AddError("O campo Senha da Conta não foi informado.");
            }
        }
    }
}