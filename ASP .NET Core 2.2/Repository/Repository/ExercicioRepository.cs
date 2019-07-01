using Domain.Repository;
using Repository.Context;

namespace Repository.Repository
{
    public class ExercicioRepository : BaseRepository<Domain.DTO.Exercicio>, IExercicioRepository
    {
        public ExercicioRepository(SmartgymContext smartgymContext) : base(smartgymContext)
        {

        }
    }
}