using consultaCep_backend.Database;
using consultaCep_backend.Entities;

namespace consultaCep_backend.Application.GetAll
{
    public class GetAllEnderecosService : IGetAllEnderecosService
    {
        private readonly Context _db;
        public GetAllEnderecosService(Context db)
        {
            _db = db;
        }
        public async Task<List<EnderecoEntite>> GetAll(string search)
        {
            var enderecos = _db.Enderecos.Where(s =>
                                                    !string.IsNullOrEmpty(search) ||
                                                    s.Bairro.Contains(search) ||
                                                    s.Localidade.Contains(search) ||
                                                    s.Complemento.Contains(search))
                                         .Select(res => res).ToList();

            return enderecos;
        }
    }
}
