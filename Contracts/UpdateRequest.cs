namespace consultaCep_backend.Contracts
{
    public record UpdateRequest(string Bairro, 
        string Complemento, 
        string Localidade,
        string Uf,
        string Guia,
        long Unidade,
        int Ibge,
        int Id
        );
   
}
