using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTO
{
    public class Professor : DTODefault
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

        public long? IdAgendaProfessor { get; set; }

        [ForeignKey("IdAgendaProfessor")]
        public virtual Agenda AgendaProfessor { get; set; }

        public int PermissaoProfessor { get; set; }

        public string CrefProfessor { get; set; }

        public string NomeProfessor { get; set; }

        public long CpfProfessor { get; set; }

        public DateTime DataNascimentoProfessor { get; set; }

        public DateTime DataAdmissaoProfessor { get; set; }

        public long TelefoneProfessor { get; set; }

        public long CelularProfessor { get; set; }

        public int SexoProfessor { get; set; }

        public int IdadeProfessor { get; set; }

        public string ImagemProfessor { get; set; }

        public override void Validate()
        {
            ClearValidateMensages();

            if (PermissaoProfessor < 1)
            {
                AddError("O campo Permissão do Professor não foi informado.");
            }

            if (CrefProfessor.Length < 11)
            {
                AddError("O campo CREF do Professor não foi informado.");
            }

            if (NomeProfessor.Length < 1)
            {
                AddError("O campo Nome do Professor não foi informado.");
            }

            if (CpfProfessor.ToString().Length < 11)
            {
                AddError("O campo CPF do Professor não foi informado.");
            }

            if (DataNascimentoProfessor.ToString().Length < 1)
            {
                AddError("O campo Data de Nascimento do Professor não foi informado.");
            }

            if (DataAdmissaoProfessor.ToString().Length < 1)
            {
                AddError("O campo Data de Admissão do Professor não foi informado.");
            }

            if (SexoProfessor.ToString().Length < 1)
            {
                AddError("O campo Sexo do Professor não foi informado.");
            }

            if (IdadeProfessor < 1)
            {
                AddError("O campo Idade do Professor não foi informado.");
            }
        }
    }
}