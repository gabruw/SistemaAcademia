using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTO
{
    public class Aluno : DTODefault
    {
        public Aluno()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAluno { get; set;  }

        public int IdEnderecoAluno { get; set;  }

        [ForeignKey("IdEnderecoAluno")]
        public virtual Endereco EnderecoAluno { get; set; }

        public virtual ICollection<Ficha> FichaAluno { get; set; }

        public virtual ICollection<Avaliacao> AvaliacaoAluno { get; set; }

        public int PermissaoAluno { get; set; }

        public string EmailAluno { get; set; }

        public string SenhaAluno { get; set; }

        public string MatriculaAluno { get; set; }

        public string NomeAluno { get; set; }

        public int CpfAluno { get; set; }

        public DateTime DataNascimentoAluno { get; set; }

        public int TelefoneAluno { get; set; }

        public int CelularAluno { get; set; }

        public int SexoAluno { get; set; }

        public string ImagemAluno { get; set; }

        public override void Validate()
        {
            ClearValidateMensages();

            if (PermissaoAluno < 1)
            {
                AddError("O campo Permissão do Aluno não foi informado.");
            }

            if (EmailAluno.Length < 1)
            {
                AddError("O campo Email do Aluno não foi informado.");
            }

            if (SenhaAluno.Length < 1)
            {
                AddError("O campo Senha do Aluno não foi informado.");
            }

            if (MatriculaAluno.Length < 1)
            {
                AddError("O campo Matrícula do Aluno não foi informado.");
            }

            if (NomeAluno.Length < 1)
            {
                AddError("O campo Nome do Aluno não foi informado.");
            }

            if (CpfAluno.ToString().Length < 11)
            {
                AddError("O campo CPF do Aluno não foi informado.");
            }

            if (DataNascimentoAluno.ToString().Length < 1)
            {
                AddError("O campo Data de Nascimento do Aluno não foi informado.");
            }

            if (TelefoneAluno.ToString().Length < 8 && CelularAluno.ToString().Length < 9)
            {
                AddError("O campo Telefone ou Celular do Professor não foi informado.");
            }

            if (SexoAluno.ToString().Length < 1)
            {
                AddError("O campo Sexo do Aluno não foi informado.");
            }
        }
    }
}