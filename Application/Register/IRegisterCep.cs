namespace consultaCep_backend.Application.Register
{
    public interface IRegisterCep
    {
        Task<string> Register(string Cep);
    }
}
