using Domain.DTO;
using System.Collections.Generic;

namespace Auxiliary.Partial
{
    public class PartialCollectionProfessorAluno
    {
        public IEnumerable<Professor> Professor { get; set; }

        public IEnumerable<Aluno> Aluno { get; set; }
    }
}