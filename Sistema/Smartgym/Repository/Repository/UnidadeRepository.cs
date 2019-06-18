using Domain.Repository;
using Repository.Context;

namespace Repository.Repository
{
    public class UnidadeRepository : BaseRepository<Domain.DTO.Unidade>, IUnidadeRepository
    {
        public UnidadeRepository(SmartgymContext smartgymContext) : base(smartgymContext)
        {

        }
    }
}