using consultaCep_backend.Contracts;
using consultaCep_backend.Database;

namespace consultaCep_backend.Application.Update
{
    public class UpdateEnderecosService : IUpdateEnderecosService
    {
        private readonly Context _db;
        public UpdateEnderecosService(Context db)
        {
            _db = db;
        }
        public async Task<string> Update(UpdateRequest request)
        {
            if (request.Id < 0)
                return "digite o id!";

            var checkHasId = await _db.Enderecos.FindAsync(request.Id);

            checkHasId.Complemento = !string.IsNullOrEmpty(request.Complemento)
                                     ? checkHasId.Complemento : request.Complemento;

            checkHasId.Localidade = !string.IsNullOrEmpty(request.Localidade)
                                     ? checkHasId.Localidade 
                                     : request.Localidade;

            checkHasId.Uf = !string.IsNullOrEmpty(checkHasId.Localidade)
                                    ? checkHasId.Uf 
                                    : request.Uf;

            checkHasId.Gia = !string.IsNullOrEmpty(request.Guia)
                                    ? checkHasId.Gia
                                    : request.Guia;


            checkHasId.Unidade = request.Unidade != null 
                                    ? request.Unidade 
                                    : checkHasId.Unidade;

            checkHasId.Ibge = request.Ibge != null 
                                    ? request.Ibge 
                                    : checkHasId.Ibge;

             _db.Enderecos.Update(checkHasId);

            return "atualizado com sucesso!";
        }
    }
}
