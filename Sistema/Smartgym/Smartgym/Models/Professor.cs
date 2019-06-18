using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smartgym.Models
{
    public class Professor
    {
        public Professor()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProfessor { get; set; }

        public int IdEnderecoProfessor { get; set; }

        [ForeignKey("IdEnderecoProfessor")]
        public virtual Endereco EnderecoProfessor { get; set; }

        public int IdUnidadeProfessor { get; set; }

        [ForeignKey("IdUnidadeProfessor")]
        public virtual Unidade UnidadeProfessor { get; set; }

        public int IdAgendaProfessor { get; set; }

        [ForeignKey("IdAgendaProfessor")]
        public virtual Agenda AgendaProfessor { get; set; }

        [MinLength(1)]
        [MaxLength(1)]
        [Required(ErrorMessage = "Necessário adicionar uma Permissão ao Professor.")]
        public int PermissaoProfessor { get; set; }

        [MinLength(4)]
        [MaxLength(60)]
        [Required(ErrorMessage = "Necessário adicionar um Email ao Professor.")]
        public string EmailProfessor { get; set; }

        [MinLength(5)]
        [MaxLength(40)]
        [Required(ErrorMessage = "Necessário adicionar uma Senha ao Professor.")]
        public string SenhaProfessor { get; set; }

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
        public int CpfProfessor { get; set; }

        public DateTime DataNascimentoProfessor { get; set; }

        public DateTime DataAdmissaoProfessor { get; set; }

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