using consultaCep_backend.Database;
using consultaCep_backend.Entities;
using consultaCep_backend.interactor;

namespace consultaCep_backend.Application.Register
{
    public class RegisterCep : IRegisterCep
    {
        private readonly Context _db;
        private readonly ISearchByZipCodeInteractor _iSearchByZipCodeInteractor;
        public RegisterCep(Context db, ISearchByZipCodeInteractor iSearchByZipCodeInteractor)
        {
            _db = db;
            _iSearchByZipCodeInteractor = iSearchByZipCodeInteractor;
        }
        public async Task<string> Register(string Cep)
        {
            if (!string.IsNullOrEmpty(Cep))
                return "digite o cep";

            var checkHasCep =  _db.Enderecos.Where(c => c.Cep.Equals(Cep));

            if (checkHasCep.Any())
                return "Cep já existente";

            var consult = await _iSearchByZipCodeInteractor.SearchByZipCode(Cep);

            if (consult == null)
                return "cep nao encontrado !";

            var endereco = new EnderecoEntite
            {
                Cep = consult.Cep,
                Logradouro = consult.Rua,
                Complemento = consult.Complemento,
                Bairro = consult.Bairro,
                Localidade = consult.Bairro,
                Uf = consult.EstadoUf,
                Unidade = long.Parse(consult.Unidade),
                Ibge = Convert.ToInt32(consult.Ibge),
                Gia = consult.Gia
            };

            var create = await _db.Enderecos.AddAsync(endereco);
            await _db.SaveChangesAsync();

            return "cadastrado com sucesso !";


        }
    }
}
