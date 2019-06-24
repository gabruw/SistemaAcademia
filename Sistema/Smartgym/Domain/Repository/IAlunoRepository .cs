using Domain.DTO;

namespace Domain.Repository
{
    public interface IAlunoRepository : IBaseRepository<Aluno>
    {
        long VerifyCpf(Aluno entity);
    }
}