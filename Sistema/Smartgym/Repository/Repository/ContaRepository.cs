using Domain.Repository;
using Repository.Context;

namespace Repository.Repository
{
    public class ContaRepository : BaseRepository<Domain.DTO.Conta>, IContaRepository
    {
        public ContaRepository(SmartgymContext smartgymContext) : base(smartgymContext)
        {
           
        }

        public long Logar(Domain.DTO.Conta entity)
        {
            try
            {
                var conta = SmartgymContext.Set<Domain.DTO.Conta>().Find(entity.EmailConta);

                if (conta.SenhaConta == entity.SenhaConta)
                {
                    return conta.IdConta;
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}