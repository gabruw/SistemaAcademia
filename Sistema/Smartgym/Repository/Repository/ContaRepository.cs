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
            var conta = SmartgymContext.Set<Domain.DTO.Conta>().Find(entity.EmailConta);

            if (conta.EmailConta.Length < 4)
            {
                if(conta.SenhaConta == entity.SenhaConta)
                {
                    return conta.IdConta;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}