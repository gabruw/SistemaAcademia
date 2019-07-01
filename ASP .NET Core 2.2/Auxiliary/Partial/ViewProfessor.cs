using Domain.DTO;
using System.Collections.Generic;

namespace Auxiliary.Partial
{
    public class ViewProfessor
    {
        public Professor Professor { get; set; }

        public IEnumerable<Unidade> Unidade { get; set; }
    }
}