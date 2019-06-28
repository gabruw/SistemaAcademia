using Domain.Repository;
using Repository.Context;

namespace Repository.Repository
{
    public class ProfessorRepository : BaseRepository<Domain.DTO.Professor>, IProfessorRepository
    {
        public ProfessorRepository(SmartgymContext smartgymContext) : base(smartgymContext)
        {

        }
    }
}