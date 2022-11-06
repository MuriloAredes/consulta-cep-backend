namespace consultaCep_backend.Application.Delete
{
    public interface IDeleteEnderecoService
    {
        Task<string> Delete(int id);
    }
}
