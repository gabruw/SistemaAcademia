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
        public int IdProfessor { get; set; }

        public int IdUnidadeProfessor { get; set; }

        [ForeignKey("IdUnidadeProfessor")]
        public virtual Unidade UnidadeProfessor { get; set; }

        public int IdAgendaProfessor { get; set; }

        [ForeignKey("IdAgendaProfessor")]
        public virtual Agenda AgendaProfessor { get; set; }

        public int PermissaoProfessor { get; set; }

        public string EmailProfessor { get; set; }

        public string SenhaProfessor { get; set; }

        public string CrefProfessor { get; set; }

        public string NomeProfessor { get; set; }

        public int CpfProfessor { get; set; }

        public DateTime DataNascimentoProfessor { get; set; }

        public DateTime DataAdmissaoProfessor { get; set; }

        public int TelefoneProfessor { get; set; }

        public int CelularProfessor { get; set; }

        public int SexoProfessor { get; set; }

        public int CepProfessor { get; set; }

        public string RuaEnderecoProfessor { get; set; }

        public string BairroEnderecoProfessor { get; set; }

        public int NumeroEnderecoProfessor { get; set; }

        public int ComplementoEnderecoProfessor { get; set; }

        public string ImagemProfessor { get; set; }

        public override void Validate()
        {
            ClearValidateMensages();

            if (CepProfessor.ToString().Length < 8)
            {
                AddError("O campo CEP da Professor não foi informado.");
            }

            if (PermissaoProfessor < 1)
            {
                AddError("O campo Permissão do Professor não foi informado.");
            }

            if (EmailProfessor.Length < 1)
            {
                AddError("O campo Email do Professor não foi informado.");
            }

            if (SenhaProfessor.Length < 1)
            {
                AddError("O campo Senha do Professor não foi informado.");
            }

            if (CrefProfessor.Length < 1)
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

            if (TelefoneProfessor.ToString().Length < 8 && CelularProfessor.ToString().Length < 9)
            {
                AddError("O campo Telefone ou Celular do Professor não foi informado.");
            }

            if (SexoProfessor.ToString().Length < 1)
            {
                AddError("O campo Sexo do Professor não foi informado.");
            }

            if (RuaEnderecoProfessor.Length < 1)
            {
                AddError("O campo Rua do Endereço do Professor não foi informado.");
            }

            if (BairroEnderecoProfessor.Length < 1)
            {
                AddError("O campo Bairro do Endereço do Professor não foi informado.");
            }

            if (NumeroEnderecoProfessor.ToString().Length < 1)
            {
                AddError("O campo Número do Endereço do Professor não foi informado.");
            }
        }
    }
}