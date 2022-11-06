using consultaCep_backend.Database;

namespace consultaCep_backend.Application.Delete
{
    public class DeleteEnderecoService : IDeleteEnderecoService
    {
        private readonly Context _db;
        public DeleteEnderecoService(Context db)
        {
            _db = db;
        }

        public async Task<string> Delete(int id)
        {
            if (id == 0 || id < 0)
                return "digite id";

            var checkId = await _db.Enderecos.FindAsync(id);

            if (checkId == null)
                return "id nao encontrado";

             _db.Enderecos.Remove(checkId);

            return "deletado com sucesso !";
        }
    }
}
