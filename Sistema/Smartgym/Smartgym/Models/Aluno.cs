using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smartgym.Models
{
    public class Aluno
    {
        public Aluno()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdAluno { get; set; }

        public long IdContaAluno { get; set; }

        [ForeignKey("IdContaAluno")]
        public virtual Conta ContaAluno { get; set; }

        public long IdEnderecoAluno { get; set; }

        [ForeignKey("IdEnderecoAluno")]
        public virtual Endereco EnderecoAluno { get; set; }

        public virtual ICollection<Ficha> FichaAluno { get; set; }

        public virtual ICollection<Avaliacao> AvaliacaoAluno { get; set; }

        [MinLength(1)]
        [MaxLength(1)]
        [Required(ErrorMessage = "Necessário adicionar uma Permissão ao Aluno.")]
        public int PermissaoAluno { get; set; }

        [MinLength(8)]
        [MaxLength(8)]
        [Required(ErrorMessage = "Necessário adicionar uma Matrícula ao Aluno.")]
        public string MatriculaAluno { get; set; }

        [MinLength(1)]
        [MaxLength(120)]
        [Required(ErrorMessage = "Necessário adicionar um Nome ao Aluno.")]
        public string NomeAluno { get; set; }

        [MinLength(11)]
        [MaxLength(11)]
        [Required(ErrorMessage = "Necessário adicionar um CPF ao Aluno.")]
        public long CpfAluno { get; set; }

        public DateTime DataNascimentoAluno { get; set; }

        public int TelefoneAluno { get; set; }

        public int CelularAluno { get; set; }

        [MinLength(1)]
        [MaxLength(1)]
        [Required(ErrorMessage = "Necessário adicionar um Sexo ao Aluno.")]
        public int SexoAluno { get; set; }

        [MinLength(1)]
        [MaxLength(9)]
        [Required(ErrorMessage = "Necessário adicionar um Nome ao Aluno.")]
        public int CepAluno { get; set; }

        [MinLength(64)]
        [MaxLength(64)]
        [Required(ErrorMessage = "Necessário adicionar uma Imagem ao Aluno.")]
        public string ImagemAluno { get; set; }
    }
}