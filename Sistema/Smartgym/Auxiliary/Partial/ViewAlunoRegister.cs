using Domain.DTO;

namespace Smartgym.Models
{
    public class ViewAlunoRegister
    {
        public Aluno AlunoViewAluno { get; set; }

        public Conta ContaViewAluno { get; set; }

        public Endereco EnderecoViewAluno { get; set; }
    }
}