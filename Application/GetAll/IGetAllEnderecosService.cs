using consultaCep_backend.Entities;

namespace consultaCep_backend.Application.GetAll
{
    public interface IGetAllEnderecosService
    {
        Task<List<EnderecoEntite>> GetAll(string search);
    }
}
