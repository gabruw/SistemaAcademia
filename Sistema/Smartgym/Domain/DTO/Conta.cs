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
        public long IdConta { get; set;  }

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