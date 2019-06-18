using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTO
{
    public class Aparelho : DTODefault
    {
        public Aparelho()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAparelho { get; set; }

        public string NomeAparelho { get; set; }

        public override void Validate()
        {
            ClearValidateMensages();

            if (NomeAparelho.Length < 1)
            {
                AddError("O campo Nome do Aparelho não foi informado.");
            }
        }
    }
}