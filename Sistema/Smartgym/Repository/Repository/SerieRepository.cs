using Domain.Repository;
using Repository.Context;

namespace Repository.Repository
{
    public class SerieRepository : BaseRepository<Domain.DTO.Serie>, ISerieRepository
    {
        public SerieRepository(SmartgymContext smartgymContext) : base(smartgymContext)
        {

        }
    }
}