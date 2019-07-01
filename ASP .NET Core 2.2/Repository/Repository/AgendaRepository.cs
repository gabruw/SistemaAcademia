using Domain.Repository;
using Repository.Context;

namespace Repository.Repository
{
    public class AgendaRepository : BaseRepository<Domain.DTO.Agenda>, IAgendaRepository
    {
        public AgendaRepository(SmartgymContext smartgymContext) : base(smartgymContext)
        {

        }
    }
}