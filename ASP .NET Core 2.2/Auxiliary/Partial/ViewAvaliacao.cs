using Domain.DTO;
using System.Collections.Generic;

namespace Auxiliary.Partial
{
    public class ViewAvaliacao
    {
        public Avaliacao AvaliacaoViewAvaliacao { get; set; }

        public IEnumerable<Professor> ProfessorViewAvaliacao { get; set; }

        public IEnumerable<Aluno> AlunoViewAvaliacao { get; set; }
    }
}