using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smartgym.Models
{
    public class Avaliacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdAvaliacao { get; set; }

        public long IdAlunoAvaliacao { get; set; }

        [ForeignKey("IdAlunoAvaliacao")]
        public virtual Aluno AlunoAvaliacao { get; set; }

        public long IdProfessorAvaliacao { get; set; }

        [ForeignKey("IdProfessorAvaliacao")]
        public virtual Professor ProfessorAvaliacao { get; set; }

        public DateTime DataAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar uma Altura a Avaliação.")]
        public double AlturaAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar um Peso a Avaliação.")]
        public double PesoAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar um IMC a Avaliação.")]
        public double ImcAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar uma Medida do Braço Direito a Avaliação.")]
        public double BracoDireitoAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar uma Medida do Braço Esquerdo a Avaliação.")]
        public double BracoEsquerdoAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar uma Medida do Peitoral a Avaliação.")]
        public double PeitoralAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar uma Medida do Abdomem a Avaliação.")]
        public double AbdomemAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar uma Medida do Quadril a Avaliação.")]
        public double QuadrilAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar uma Medida do Quadriceps Direito a Avaliação.")]
        public double QuadricepsDireitoAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar uma Medida do Quadriceps Esquerdo a Avaliação.")]
        public double QuadrcepsEsquerdoAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar uma Medida da Panturrilha a Avaliação.")]
        public double PanturrilhaDireitaAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar uma Medida da Panturrilha Esquerda a Avaliação.")]
        public double PanturrilhaEsquerdaAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar uma Medida da Dobra Cutânea do Peito a Avaliação.")]
        public double DobraCutaneaPeitoAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar uma Medida da Dobra Cutânea da Coxa a Avaliação.")]
        public double DobraCutaneaCoxaAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar uma Medida da Dobra Cutânea do Triceps a Avaliação.")]
        public double DobraCutaneaTricepsAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar uma Medida da Dobra Cutânea do Abdomem a Avaliação.")]
        public double DobraCutaneaAbdomemAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar uma Medida da Dobra Cutânea do Quadril a Avaliação.")]
        public double DobraCutaneaQuadrilAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar uma Medida da Dobra Cutânea da Panturrilha a Avaliação.")]
        public double DobraCutaneaPanturrilhaAvaliacao { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "Necessário adicionar um Percentual de Godura Avaliação.")]
        public double PercentualGorduraAvaliacao { get; set; }

        public string ObservacaoAvaliacao { get; set; }
    }
}