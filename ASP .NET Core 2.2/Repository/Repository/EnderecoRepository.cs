using Domain.Repository;
using Repository.Context;

namespace Repository.Repository
{
    public class EnderecoRepository : BaseRepository<Domain.DTO.Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(SmartgymContext smartgymContext) : base(smartgymContext)
        {

        }
    }
}