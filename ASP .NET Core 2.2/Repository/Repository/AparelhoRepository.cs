using Domain.Repository;
using Repository.Context;

namespace Repository.Repository
{
    public class AparelhoRepository : BaseRepository<Domain.DTO.Aparelho>, IAparelhoRepository
    {
        public AparelhoRepository(SmartgymContext smartgymContext) : base(smartgymContext)
        {

        }
    }
}