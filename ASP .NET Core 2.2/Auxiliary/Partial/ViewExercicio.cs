using Domain.DTO;
using System.Collections.Generic;

namespace Auxiliary.Partial
{
    public class ViewExercicio
    {
        public Exercicio ExercicioViewExercicio { get; set; }

        public IEnumerable<Aparelho> AparelhorViewAgenda { get; set; }
    }
}