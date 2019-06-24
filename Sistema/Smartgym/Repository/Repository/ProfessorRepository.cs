using Domain.Repository;
using Repository.Context;

namespace Repository.Repository
{
    public class ProfessorRepository : BaseRepository<Domain.DTO.Professor>, IProfessorRepository
    {
        public ProfessorRepository(SmartgymContext smartgymContext) : base(smartgymContext)
        {

        }

        public long VerifyCpf(Domain.DTO.Professor entity)
        {
            try
            {
                var conta = SmartgymContext.Set<Domain.DTO.Professor>().Find(entity.CpfProfessor);

                return 0;
            }
            catch
            {
                return 1;
            }
        }

        public long VerifyCref(Domain.DTO.Professor entity)
        {
            try
            {
                var conta = SmartgymContext.Set<Domain.DTO.Professor>().Find(entity.CrefProfessor);

                return 0;
            }
            catch
            {
                return 1;
            }
        }
    }
}