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
        public long IdUnidade { get; set; }

        public long IdEnderecoUnidade { get; set; }

        [ForeignKey("IdEnderecoUnidade")]
        public virtual Endereco EnderecoUnidade { get; set; }

        public virtual ICollection<Professor> ProfessorUnidade { get; set; }

        public string NomeUnidade { get; set; }

        public string ImagemUnidade { get; set; }

        public override void Validate()
        {
            ClearValidateMensages();

            if (NomeUnidade.Length < 1)
            {
                AddError("O campo Nome da Unidade não foi informado.");
            }

            if (ImagemUnidade.Length < 1)
            {
                AddError("O campo Imagem da Unidade não foi informado.");
            }
        }
    }
}