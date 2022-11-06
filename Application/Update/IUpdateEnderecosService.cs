using consultaCep_backend.Contracts;

namespace consultaCep_backend.Application.Update
{
    public interface IUpdateEnderecosService
    {
        Task<string> Update(UpdateRequest request);
    }
}
