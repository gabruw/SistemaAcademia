using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTO
{
    public class Endereco : DTODefault
    {
        public Endereco()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdEndereco { get; set; }

        public int CepEndereco { get; set; }

        public string RuaEndereco { get; set; }

        public string BairroEndereco { get; set; }

        public int NumeroEndereco { get; set; }

        public int ComplementoEndereco { get; set; }

        public override void Validate()
        {
            ClearValidateMensages();

            if (CepEndereco.ToString().Length < 8)
            {
                AddError("O campo CEP do Endereço não foi informado.");
            }

            if (RuaEndereco.Length < 1)
            {
                AddError("O campo Rua do Endereço não foi informado.");
            }

            if (BairroEndereco.Length < 1)
            {
                AddError("O campo Bairro do Endereço não foi informado.");
            }

            if (NumeroEndereco.ToString().Length < 1)
            {
                AddError("O campo Número do Endereço não foi informado.");
            }
        }
    }
}