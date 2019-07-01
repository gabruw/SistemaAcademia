using Domain.Repository;
using Repository.Context;

namespace Repository.Repository
{
    public class ContaRepository : BaseRepository<Domain.DTO.Conta>, IContaRepository
    {
        public ContaRepository(SmartgymContext smartgymContext) : base(smartgymContext)
        {
            
        }
    }
}