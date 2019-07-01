using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smartgym.Models
{
    public class Endereco
    {
        public Endereco()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdEndereco { get; set; }

        [MinLength(8)]
        [MaxLength(8)]
        [Required(ErrorMessage = "Necessário adicionar um CEP ao Endereço.")]
        public int CepEndereco { get; set; }

        [MinLength(1)]
        [MaxLength(80)]
        [Required(ErrorMessage = "Necessário adicionar uma Rua ao Endereço.")]
        public string RuaEndereco { get; set; }

        [MinLength(1)]
        [MaxLength(80)]
        [Required(ErrorMessage = "Necessário adicionar um Bairro ao Endereço.")]
        public string BairroEndereco { get; set; }

        [MinLength(1)]
        [MaxLength(5)]
        [Required(ErrorMessage = "Necessário adicionar um Número ao Endereço.")]
        public int NumeroEndereco { get; set; }

        public int ComplementoEndereco { get; set; }
    }
}