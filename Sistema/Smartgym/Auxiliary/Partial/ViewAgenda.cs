using Domain.DTO;
using System.Collections.Generic;

namespace Auxiliary.Partial
{
    public class ViewAgenda
    {
        public Agenda AgendaViewAgenda { get; set; }

        public IEnumerable<Professor> ProfessorViewAgenda { get; set; }

        public IEnumerable<Aluno> AlunoViewAgenda { get; set; }
    }
}