using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smartgym.Models
{
    public class Professor
    {
        public Professor()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdProfessor { get; set; }

        public long IdContaProfessor { get; set; }

        [ForeignKey("IdContaProfessor")]
        public virtual Conta ContaProfessor { get; set; }

        public long IdEnderecoProfessor { get; set; }

        [ForeignKey("IdEnderecoProfessor")]
        public virtual Endereco EnderecoProfessor { get; set; }

        public long IdUnidadeProfessor { get; set; }

        [ForeignKey("IdUnidadeProfessor")]
        public virtual Unidade UnidadeProfessor { get; set; }

        public long IdAgendaProfessor { get; set; }

        [ForeignKey("IdAgendaProfessor")]
        public virtual Agenda AgendaProfessor { get; set; }

        [MinLength(1)]
        [MaxLength(1)]
        [Required(ErrorMessage = "Necessário adicionar uma Permissão ao Professor.")]
        public int PermissaoProfessor { get; set; }

        [MinLength(8)]
        [MaxLength(8)]
        [Required(ErrorMessage = "Necessário adicionar uma Matrícula ao Professor.")]
        public string CrefProfessor { get; set; }

        [MinLength(1)]
        [MaxLength(120)]
        [Required(ErrorMessage = "Necessário adicionar um Nome ao Professor.")]
        public string NomeProfessor { get; set; }

        [MinLength(11)]
        [MaxLength(11)]
        [Required(ErrorMessage = "Necessário adicionar um CPF ao Professor.")]
        public long CpfProfessor { get; set; }

        public DateTime DataNascimentoProfessor { get; set; }

        public DateTime DataAdmissaoProfessor { get; set; }

        public long TelefoneProfessor { get; set; }

        public long CelularProfessor { get; set; }

        [MinLength(1)]
        [MaxLength(1)]
        [Required(ErrorMessage = "Necessário adicionar um Sexo ao Professor.")]
        public int SexoProfessor { get; set; }

        [MinLength(1)]
        [MaxLength(9)]
        [Required(ErrorMessage = "Necessário adicionar um Nome ao Professor.")]
        public int CepProfessor { get; set; }

        [MinLength(64)]
        [MaxLength(64)]
        [Required(ErrorMessage = "Necessário adicionar uma Imagem ao Professor.")]
        public string ImagemProfessor { get; set; }
    }
}