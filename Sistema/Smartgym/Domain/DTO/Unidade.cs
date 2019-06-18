using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTO
{
    public class Unidade : DTODefault
    {
        public Unidade()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUnidade { get; set; }

        public virtual ICollection<Professor> ProfessorUnidade { get; set; }

        public int CepUnidade { get; set; }

        public string RuaEnderecoUnidade { get; set; }

        public string BairroEnderecoUnidade { get; set; }

        public int NumeroEnderecoUnidade { get; set; }

        public int ComplementoEnderecoUnidade { get; set; }

        public override void Validate()
        {
            ClearValidateMensages();

            if (CepUnidade.ToString().Length < 8)
            {
                AddError("O campo CEP da Unidade não foi informado.");
            }

            if (RuaEnderecoUnidade.Length < 1)
            {
                AddError("O campo Rua do Endereço da Unidade não foi informado.");
            }

            if (BairroEnderecoUnidade.Length < 1)
            {
                AddError("O campo Bairro do Endereço da Unidade não foi informado.");
            }

            if (NumeroEnderecoUnidade.ToString().Length < 1)
            {
                AddError("O campo Número do Endereço da Unidade não foi informado.");
            }
        }
    }
}