using Domain.Repository;
using Repository.Context;

namespace Repository.Repository
{
    public class AlunoRepository : BaseRepository<Domain.DTO.Aluno>, IAlunoRepository
    {
        public AlunoRepository(SmartgymContext smartgymContext) : base(smartgymContext)
        {
           
        }

        public long VerifyCpf(Domain.DTO.Aluno entity)
        {
            try
            {
                var conta = SmartgymContext.Set<Domain.DTO.Aluno>().Find(entity.CpfAluno);

                return 0;
            }
            catch
            {
                return 1;
            }
        }
    }
}