using Domain.DTO;

namespace Domain.Repository
{
    public interface IContaRepository : IBaseRepository<Conta>
    {
        Conta Logar(Conta entity);
    }
}