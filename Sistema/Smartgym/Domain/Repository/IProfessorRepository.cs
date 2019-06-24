using Domain.DTO;

namespace Domain.Repository
{
    public interface IProfessorRepository : IBaseRepository<Professor>
    {
        long VerifyCpf(Professor entity);

        long VerifyCref(Professor entity);
    }
}