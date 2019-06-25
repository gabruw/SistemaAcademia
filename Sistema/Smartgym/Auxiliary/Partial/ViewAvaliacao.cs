using Domain.DTO;
using System.Collections.Generic;

namespace Auxiliary.Partial
{
    public class ViewAvaliacao
    {
        public IEnumerable<Professor> ProfessorViewAgenda { get; set; }

        public IEnumerable<Aluno> AlunoViewAgenda { get; set; }
    }
}