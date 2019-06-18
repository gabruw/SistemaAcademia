using Domain.Repository;
using Repository.Context;

namespace Repository.Repository
{
    public class AvaliacaoRepository : BaseRepository<Domain.DTO.Avaliacao>, IAvaliacaoRepository
    {
        public AvaliacaoRepository(SmartgymContext smartgymContext) : base(smartgymContext)
        {

        }
    }
}