using Domain.Repository;
using Repository.Context;

namespace Repository.Repository
{
    public class ContaRepository : BaseRepository<Domain.DTO.Conta>, IContaRepository
    {
        public ContaRepository(SmartgymContext smartgymContext) : base(smartgymContext)
        {
           
        }

        public Domain.DTO.Conta Logar(Domain.DTO.Conta entity)
        {
            var entidadeBanco = SmartgymContext.Set<Domain.DTO.Conta>().Find(entity.EmailConta);
            var senha = entidadeBanco.SenhaConta;

            if (entidadeBanco != null)
            {
                entidadeBanco.EmailConta = "Email inválido!";
            }
            else if (senha != entity.SenhaConta)
            {
                entidadeBanco.EmailConta = "Senha inválida!";
            }

            return entidadeBanco;
        }
    }
}