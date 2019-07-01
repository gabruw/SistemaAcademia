using Domain.Repository;
using Repository.Context;

namespace Repository.Repository
{
    public class ExercicioSerieRepository : BaseRepository<Domain.DTO.ExercicioSerie>, IExercicioSerieRepository
    {
        public ExercicioSerieRepository(SmartgymContext smartgymContext) : base(smartgymContext)
        {

        }
    }
}