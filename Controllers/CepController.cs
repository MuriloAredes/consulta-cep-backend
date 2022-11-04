using consultaCep_backend.Database;
using consultaCep_backend.Entities;
using consultaCep_backend.interactor;
using Microsoft.AspNetCore.Mvc;

namespace consultaCep_backend.Controllers
{
    [ApiController]
    [Produces("application/json")]

    public class CepController : Controller
    {
        private readonly ISearchByZipCodeInteractor _iSearchByZipCodeInteractor;
        private readonly Context _db;
        public CepController(ISearchByZipCodeInteractor iSearchByZipCodeInteractor,
            Context db)
        {
            _iSearchByZipCodeInteractor = iSearchByZipCodeInteractor;
            _db = db;

        }

        [HttpPost("api/[controller]/register")]
        public async Task<IActionResult> Register([FromBody] string cep)
        {
            try
            {

                if (string.IsNullOrEmpty(cep))
                    return BadRequest("insira um cep");

                var consult = await _iSearchByZipCodeInteractor.SearchByZipCode("13088-106");

                if (consult == null)
                    return BadRequest("cep não encontrado ");


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

                return Ok("cadastrado");


            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpGet("api/[controller]/getAll")]
        public async Task<IActionResult> GetAll( string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    return BadRequest("search nao pode ser nulo");

                var result =  _db.Enderecos.Where(s => s.Localidade.Contains(search)).Select(res => res).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}