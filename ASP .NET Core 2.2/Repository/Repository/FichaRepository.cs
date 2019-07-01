using Domain.Repository;
using Repository.Context;

namespace Repository.Repository
{
    public class FichaRepository : BaseRepository<Domain.DTO.Ficha>, IFichaRepository
    {
        public FichaRepository(SmartgymContext smartgymContext) : base(smartgymContext)
        {

        }
    }
}