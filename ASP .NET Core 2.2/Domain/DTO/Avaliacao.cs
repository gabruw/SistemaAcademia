using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTO
{
    public class Avaliacao : DTODefault
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

        public double AlturaAvaliacao { get; set; }

        public double PesoAvaliacao { get; set; }

        public double ImcAvaliacao { get; set; }

        public double BracoDireitoAvaliacao { get; set; }

        public double BracoEsquerdoAvaliacao { get; set; }

        public double PeitoralAvaliacao { get; set; }

        public double AbdomemAvaliacao { get; set; }

        public double QuadrilAvaliacao { get; set; }

        public double QuadricepsDireitoAvaliacao { get; set; }

        public double QuadrcepsEsquerdoAvaliacao { get; set; }

        public double PanturrilhaDireitaAvaliacao { get; set; }

        public double PanturrilhaEsquerdaAvaliacao { get; set; }

        public double DobraCutaneaPeitoAvaliacao { get; set; }

        public double DobraCutaneaCoxaAvaliacao { get; set; }

        public double DobraCutaneaTricepsAvaliacao { get; set; }

        public double DobraCutaneaAbdomemAvaliacao { get; set; }

        public double DobraCutaneaQuadrilAvaliacao { get; set; }

        public double DobraCutaneaPanturrilhaAvaliacao { get; set; }

        public double PercentualGorduraAvaliacao { get; set; }

        public string ObservacaoAvaliacao { get; set; }

        public override void Validate()
        {
            ClearValidateMensages();

            if (DataAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Data da Avaliação não foi informado.");
            }

            if (AlturaAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Altura da Avaliação não foi informado.");
            }

            if (PesoAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Peso da Avaliação não foi informado.");
            }

            if (ImcAvaliacao.ToString().Length < 1)
            {
                AddError("O campo IMC da Avaliação não foi informado.");
            }

            if (BracoDireitoAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Braço Direito da Avaliação não foi informado.");
            }

            if (BracoEsquerdoAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Braço Esquerdo da Avaliação não foi informado.");
            }

            if (PeitoralAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Peitoral da Avaliação não foi informado.");
            }

            if (AbdomemAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Abdomem da Avaliação não foi informado.");
            }

            if (QuadrilAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Quadril da Avaliação não foi informado.");
            }

            if (QuadricepsDireitoAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Quadriceps Direito da Avaliação não foi informado.");
            }

            if (QuadrcepsEsquerdoAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Quadriceps Esquerdo da Avaliação não foi informado.");
            }

            if (PanturrilhaDireitaAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Panturrilha Direito da Avaliação não foi informado.");
            }

            if (PanturrilhaEsquerdaAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Panturrilha Esquerda da Avaliação não foi informado.");
            }

            if (DobraCutaneaPeitoAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Dobra Cutânea do Peito da Avaliação não foi informado.");
            }

            if (DobraCutaneaCoxaAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Dobra Cutânea do Coxa da Avaliação não foi informado.");
            }

            if (DobraCutaneaTricepsAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Dobra Cutânea do Triceps da Avaliação não foi informado.");
            }

            if (DobraCutaneaAbdomemAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Dobra Cutânea do Abdomem da Avaliação não foi informado.");
            }

            if (DobraCutaneaQuadrilAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Dobra Cutânea do Quadril da Avaliação não foi informado.");
            }

            if (DobraCutaneaPanturrilhaAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Dobra Cutânea da Panturrilha da Avaliação não foi informado.");
            }

            if (PercentualGorduraAvaliacao.ToString().Length < 1)
            {
                AddError("O campo Percentual de Gordura da Avaliação não foi informado.");
            }
        }
    }
}