using Domain.DTO;

namespace Domain.Repository
{
    public interface IContaRepository : IBaseRepository<Conta>
    {
        long Logar(Conta entity);
    }
}