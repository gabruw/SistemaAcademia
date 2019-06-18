using Domain.Repository;
using Repository.Context;

namespace Repository.Repository
{
    public class AlunoRepository : BaseRepository<Domain.DTO.Aluno>, IAlunoRepository
    {
        public AlunoRepository(SmartgymContext smartgymContext) : base(smartgymContext)
        {

        }
    }
}