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

                if(conta != null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch
            {
                return 1;
            }
        }
    }
}